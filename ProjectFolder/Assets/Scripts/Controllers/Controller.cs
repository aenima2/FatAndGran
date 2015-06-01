using UnityEngine;
using System.Collections;

public enum PInput { Keyboard01, Keyboard02, Mouse };

public class Controller : MonoBehaviour {

    public PInput m_playerInput;

    public Transform m_ground;

    public float m_speed = 10f;

    protected MeshCollider m_groundCollider;

    protected float m_inputX = 0.0f;
    protected float m_inputZ = 0.0f;

    protected string m_number;


    public virtual void Start()
    {
        m_ground = GameObject.FindGameObjectWithTag("Ground").transform;
        m_groundCollider = m_ground.GetComponent<MeshCollider>();

        if (m_playerInput == PInput.Mouse)
            return;

        m_number = m_playerInput.ToString().Substring(8, 2);
    }

    public virtual void Update()
    {
        Movement();

        if (InputManager.Instance.ButtonDown(this))
        {
            Action();
        }
    }

    protected virtual void Movement()
    {
        // HL: need check to see if character is within screen bounds
        // movement
        switch (m_playerInput)
        {
            // HL: needs something else than Translate?
            case PInput.Keyboard01:
            case PInput.Keyboard02:
                m_inputX = Input.GetAxis("Horizontal" + m_number);
                m_inputZ = Input.GetAxis("Vertical" + m_number);
                Vector3 targetPos = new Vector3(m_inputX, 0, m_inputZ);

                if (targetPos == Vector3.zero)
                {
                    return;
                }

                // HL: fix problem with player can't stand idly in turned pos
                // rotate and move
                transform.rotation = Quaternion.LookRotation(targetPos);//, Vector3.up);
                transform.Translate(targetPos * m_speed * Time.deltaTime, Space.World);
                break;
            // HL: needs to support hovering characters
            case PInput.Mouse:
                Vector3 mousePos = GetMousePosition();
                transform.position = new Vector3(mousePos.x, 0f, mousePos.z);
                break;
        }
    }

    protected virtual void Action()
    {
        Debug.Log(gameObject.name + " action");
    }


    Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (m_groundCollider.Raycast(ray, out hit, 20f))
        {
            Debug.DrawLine(ray.origin, hit.point + new Vector3(0f, 1f, 0f), Color.red);
            return hit.point;
        }

        return Vector3.zero;
    }

    bool CloseToEnemy()
    {
        return false;
    }
}
