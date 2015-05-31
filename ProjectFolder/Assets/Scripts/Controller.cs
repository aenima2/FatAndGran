using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public Transform m_targetTf;


    void Start()
    {

    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        
    }
}
