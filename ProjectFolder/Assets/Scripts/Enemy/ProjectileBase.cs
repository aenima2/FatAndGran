using UnityEngine;
using System.Collections;

public class ProjectileBase : MonoBehaviour {

    public float m_movementSpeed;

    public float m_lifeSpan;


    public virtual void Start()
    {
        Invoke("AutoKill", m_lifeSpan);
    }

    public virtual void Update()
    {
        transform.position += transform.forward * m_movementSpeed * Time.deltaTime;
    }


    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
	    {
            case "Player":
                // destroy self and player
                Destroy(gameObject);
                //GameManager.Instance.DestroyPlayer(col.gameObject.GetComponent<Controller>());
                break;
            case "Shield":
                // destroy self
                Destroy(gameObject);
                break;
	    }
    }

    void AutoKill()
    {
        Destroy(gameObject);
    }
}
