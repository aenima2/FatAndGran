using UnityEngine;
using System.Collections;

public class ProjectileBase : MonoBehaviour {

    public float m_movementSpeed;

    public virtual void Update()
    {
        transform.position += transform.forward * m_movementSpeed * Time.deltaTime;
    }


    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;

        // destroy self
        Destroy(gameObject);
    }
}
