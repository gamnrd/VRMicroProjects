using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BlockColor
{
    Green, 
    Red
}

public class Block : MonoBehaviour
{
    private GameObject block;
    private GameObject brokenBlockLeft;
    private GameObject brokenBlockRight;

    [SerializeField] BlockColor color;

    [SerializeField] private float brokenBlockForce;
    [SerializeField] private float brokenBlockTorque;
    [SerializeField] private float brokenBlockDestroyDelay;

    private void Awake()
    {
        block = transform.Find("Block").GetComponent<Transform>().gameObject;
        brokenBlockLeft = transform.Find("BlockBroken_Left").GetComponent<Transform>().gameObject;
        brokenBlockRight = transform.Find("BlockBroken_Right").GetComponent<Transform>().gameObject;
    }


    void Hit()
    {
        //Enable pieces
        block.SetActive(false);
        brokenBlockLeft.SetActive(true);
        brokenBlockRight.SetActive(true);

        //Detach pieces from parent
        brokenBlockLeft.transform.parent = null;
        brokenBlockRight.transform.parent = null;
        

        //add force to pieces
        Rigidbody leftRB = brokenBlockLeft.GetComponent<Rigidbody>();
        Rigidbody rightRB = brokenBlockRight.GetComponent<Rigidbody>();
        leftRB.AddForce(-transform.right * brokenBlockForce, ForceMode.Impulse);
        rightRB.AddForce(transform.right * brokenBlockForce, ForceMode.Impulse);

        //add toruqe
        leftRB.AddTorque(-transform.forward * brokenBlockTorque, ForceMode.Impulse);
        rightRB.AddTorque(transform.forward * brokenBlockTorque, ForceMode.Impulse);

        //Destroy pieces
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordGreen"))
        {
            if (color == BlockColor.Green &&
                GameManager.instance.leftSwordTracker.velocity.magnitude > GameManager.instance.swordHitVelocityThreshold)
            {
                GameManager.instance.AddScore();
            }
            else
            {
                GameManager.instance.HitWrongBlock();
            }
        }
        else if(other.CompareTag("SwordRed") &&
            GameManager.instance.rightSwordTracker.velocity.magnitude > GameManager.instance.swordHitVelocityThreshold)
        {
            if (color == BlockColor.Red)
            {
                GameManager.instance.AddScore();
            }
            else
            {
                GameManager.instance.HitWrongBlock();
            }
        }
        else if(other.CompareTag("MissBox"))
        {
            GameManager.instance.MissBlock();
        }

        Hit();
    }
}



