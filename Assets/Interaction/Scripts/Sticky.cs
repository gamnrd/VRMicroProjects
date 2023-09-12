using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If a stickable surface is hit, stop the sticky item from moving
        if (collision.gameObject.GetComponent<Stickable>() != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    
    //when the sticky item is grabbed, remove any move constraints
    public void DetachFromStickable()
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
