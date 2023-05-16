using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeaimantageBoitierFusible : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BoitierFusible")
        {
            rb.mass = 20;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BoitierFusible")
        {
            rb.mass = 1;
        }
    }
}
