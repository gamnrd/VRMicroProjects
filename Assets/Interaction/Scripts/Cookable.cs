using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{ 
    private MeshRenderer m_Mesh;
    [SerializeField] private float cookRate = 0.1f;
    private bool isCooking = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Mesh = transform.GetChild(1).GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking)
        {
            m_Mesh.material.color = Color.Lerp(m_Mesh.material.color, Color.black, cookRate * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CookingSurface"))
        {
            isCooking = true;
        }       
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CookingSurface"))
        {
            isCooking = false;
        }
    }
}
