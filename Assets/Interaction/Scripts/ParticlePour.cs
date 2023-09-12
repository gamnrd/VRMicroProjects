using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePour : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particle != null)
        {
            if(transform.parent.up.y < 0.0f)
            {
                particle.Play();
            }
            else
            {
                particle.Stop();
            }
        }
    }
}
