using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wetter : MonoBehaviour
{
    [SerializeField] ParticleSystem waterDrip;

    private void OnTriggerExit(Collider other)
    {
        Instantiate(waterDrip, other.transform.position, other.transform.rotation, other.transform);
    }
}
