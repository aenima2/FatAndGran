using UnityEngine;
using System.Collections;

public class OffenseController : Controller {

    public float m_attackRange;


    protected override void Action()
    {
        base.Action();

        Slam();
    }

    void Slam()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, m_attackRange);

        for (int i = 0; i < colls.Length; i++)
        {
            if (!colls[i].gameObject.CompareTag("Enemy") || colls[i].attachedRigidbody == null)
                continue;

            colls[i].gameObject.GetComponent<EnemyBase>().Incapacitate();
        }
    }
}
