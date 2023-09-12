using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float timeTillDestroy = 2f;

    private void OnEnable()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
