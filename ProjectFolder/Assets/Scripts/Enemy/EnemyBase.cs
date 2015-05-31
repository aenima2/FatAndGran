using UnityEngine;
using System.Collections;

public enum EnemyState { Attack, Move, Idle };

public class EnemyBase : MonoBehaviour {

    public EnemyState m_currentState;

    public Controller m_closestTarget;

    public float m_movementRange;
    public float m_attackRange;

    public float m_attackSpeed;

    public float m_movementSpeed;
    public float m_rotationSpeed;

    bool m_reloading = false;


    public virtual void Start()
    {
        StartCoroutine(GetClosestPlayer());
    }

    public virtual void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 10, Color.red);

        if (m_closestTarget == null)
            return;

        switch (m_currentState)
        {
            case EnemyState.Attack:
                // rotate to face target
                Vector3 targetDir = m_closestTarget.transform.position - transform.position;
                Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, m_rotationSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(lookDir);
                // attack
                if (!m_reloading)
                {
                    StartCoroutine(Attack());
                }
                break;
            case EnemyState.Move:
                // stop attacking
                StopCoroutine(Attack());
                // rotate to face target
                targetDir = m_closestTarget.transform.position - transform.position;
                lookDir = Vector3.RotateTowards(transform.forward, targetDir, m_rotationSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(lookDir);
                // move
                transform.position += transform.forward * m_movementSpeed * Time.deltaTime;
                break;
            case EnemyState.Idle:
                StopCoroutine(Attack());
                break;
        }
    }

    protected virtual IEnumerator Attack()
    {
        m_reloading = true;
        Spit();
        yield return new WaitForSeconds(m_attackSpeed);
        m_reloading = false;
    }

    void Spit()
    {
        GameObject projectile = Instantiate(Resources.Load("Projectiles/TurtleSpit", typeof(GameObject))) as GameObject;
        Vector3 forwardV3 = transform.position + transform.forward * 2;
        projectile.transform.position = new Vector3(forwardV3.x, 1f, forwardV3.z);
        projectile.transform.rotation = transform.rotation;
    }

    IEnumerator GetClosestPlayer()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, m_movementRange);
        float bestDist = 100f;

        for (int i = 0; i < colls.Length; i++)
        {
            if (!colls[i].gameObject.CompareTag("Player"))
                continue;

            float dist = Vector3.Distance(transform.position, colls[i].transform.position);
            if (dist < bestDist)
            {
                m_closestTarget = colls[i].gameObject.GetComponent<Controller>();
                bestDist = dist;
            }
        }

        if (bestDist < m_attackRange)
        {
            m_currentState = EnemyState.Attack;
        }
        else
        {
            m_currentState = EnemyState.Move;
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(GetClosestPlayer());
    }

    void OnCollisionEnter(Collision col)
    {
        if(!col.gameObject.CompareTag("Player"))
            return;

        GameManager.Instance.DestroyPlayer(col.gameObject.GetComponent<Controller>());
    }
 }
