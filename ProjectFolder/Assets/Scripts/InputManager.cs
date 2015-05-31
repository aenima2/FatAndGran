using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum IButtons{ Active, Passive, Count };

public class InputManager : MonoSingleton<InputManager> {


    public bool ButtonDown(Controller c)
    {
        switch (c.m_playerInput)
        {
            case PInput.Keyboard01:
            case PInput.Keyboard02:
                if (Input.GetButtonDown("Action" + c.m_playerInput.ToString().Substring(8, 2)))
                {
                    return true;
                }
                break;
            case PInput.Mouse:
                if (Input.GetMouseButtonDown(0))
                {
                    return true;
                }
                break;
        }

        return false;
    }

    public bool ButtonUp(Controller c)
    {
        switch (c.m_playerInput)
        {
            case PInput.Keyboard01:
            case PInput.Keyboard02:
                if (Input.GetButtonUp("Action" + c.m_playerInput.ToString().Substring(8, 2)))
                {
                    return true;
                }
                break;
            case PInput.Mouse:
                if (Input.GetMouseButtonUp(0))
                {
                    return true;
                }
                break;
        }

        return false;
    }


    //bool[] m_previousButtons = new bool[(int)IButtons.Count];
    //bool[] m_currentButtons = new bool[(int)IButtons.Count];
    //float[] m_buttonTimes = new float[(int)IButtons.Count];

    //public List<string> m_activeKeyNames;
    //public List<string> m_passiveKeyNames;


    //void Update()
    //{
    //    if (!string.IsNullOrEmpty(m_activeKeyName))
    //    {

    //    }

    //    // copy current values to previous
    //    for (int i = 0; i < (int)IButtons.Count; ++i)
    //    {
    //        m_previousButtons[i] = m_currentButtons[i];
    //    }

    //    // set current buttons
    //    m_currentButtons[(int)IButtons.Active] = Input.GetKey(m_activeKeyName);
    //    m_currentButtons[(int)IButtons.Passive] = Input.GetKey(m_passiveKeyName);

    //    // button times
    //    for (int i = 0; i < (int)IButtons.Count; ++i)
    //    {
    //        m_buttonTimes[i] = m_currentButtons[i] ? m_buttonTimes[i] + Time.deltaTime : 0.0f;
    //    }
    //}

    //public bool JoystickButtonHeld(IButtons btn)
    //{
    //    return m_currentButtons[(int)btn];
    //}

    //public bool JoystickButtonDown(IButtons btn)
    //{
    //    return !m_previousButtons[(int)btn] && m_currentButtons[(int)btn];
    //}

    //public bool JoystickButtonUp(IButtons btn)
    //{
    //    return m_previousButtons[(int)btn] && !m_currentButtons[(int)btn];
    //}
}
