using UnityEngine;
using System.Collections;

public enum PInput { Keyboard01, Keyboard02, Mouse };

public class Controller : MonoBehaviour {

    public PInput m_playerInput;

    public Transform m_targetTf;

    public float m_speed = 10f;

    float inputX = 0.0f;
    float inputZ = 0.0f;


    void Start()
    {
        m_targetTf = transform.FindChild("Mesh");
    }

    void Update()
    {
        switch (m_playerInput)
        {
            case PInput.Keyboard01:
                inputX = Input.GetAxis("Horizontal");
                inputZ = Input.GetAxis("Vertical");
                break;
            case PInput.Keyboard02:
                inputX = Input.GetAxis("Horizontal02");
                inputZ = Input.GetAxis("Vertical02");
                break;
            case PInput.Mouse:
                break;
        }

        transform.Translate(new Vector3(inputX, 0, inputZ) * m_speed * Time.deltaTime);
    }
}
