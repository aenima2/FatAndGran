using UnityEngine;
using System.Collections;

public class DefenseController : Controller {

    Transform m_shield;

    MeshCollider m_shieldCollider;

    bool m_shieldActive = false;


    public override void Start()
    {
        base.Start();

        m_shieldCollider = GetComponentInChildren<MeshCollider>();
        if (m_shieldCollider != null)
        {
            m_shield = m_shieldCollider.transform;
        }
    }

    public override void Update()
    {
        base.Update();

        if (InputManager.Instance.ButtonUp(this))
        {
            ToggleShield(false);
        }
    }


    protected override void Action()
    {
        ToggleShield(true);
    }

    void ToggleShield(bool activate)
    {
        if(activate && m_shieldActive)
            return;

        m_shieldActive = activate;
        m_shield.GetComponent<Renderer>().enabled = activate;
        m_shieldCollider.enabled = activate;
    }
}
