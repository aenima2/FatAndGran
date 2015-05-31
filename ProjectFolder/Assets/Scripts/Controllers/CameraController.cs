using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoSingleton<CameraController> {

    public float m_distanceFromGround = 10.0f;

    List<Controller> m_keyboardControllers = new List<Controller>();


    void Start()
    {
        // add keyboard controllers to list
        foreach (Controller control in FindObjectsOfType<Controller>())
        {
            if (control.m_playerInput == PInput.Mouse || m_keyboardControllers.Contains(control))
                continue;

            m_keyboardControllers.Add(control);
        }
    }

    void Update()
    {
        if (m_keyboardControllers.Count == 0)
            return;

        Vector3 targetPos = Vector3.zero;

        if (m_keyboardControllers.Count == 1)
        {
            targetPos = m_keyboardControllers[0].transform.position;
        }
        else if (m_keyboardControllers.Count > 1)
        {
            targetPos = (m_keyboardControllers[0].transform.position + m_keyboardControllers[1].transform.position) / 2;
        }

        transform.position = new Vector3(targetPos.x, m_distanceFromGround, targetPos.z - 10f);
    }

    public void RemoveTarget(Controller c)
    {
        if (m_keyboardControllers.Contains(c))
        {
            m_keyboardControllers.Remove(c);
        }
    }
}
