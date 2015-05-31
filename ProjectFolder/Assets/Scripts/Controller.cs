using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public Transform m_targetTf;


    void Start()
    {
        m_targetTf = transform.FindChild("Mesh");
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * inputX * Time.deltaTime, 0f, Vector3.forward * inputZ * Time.deltaTime));
    }
}
