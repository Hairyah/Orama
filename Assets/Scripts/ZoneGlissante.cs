using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGlissante : MonoBehaviour
{
    //public List<Rigidbody> rb;
    public Rigidbody rb;
    [SerializeField] float glissementBase = 0.95f;
    [SerializeField] float glissementGlissante = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        //rb.Add(other.gameObject.GetComponent<Rigidbody>());
        rb = other.gameObject.GetComponent<Rigidbody>();

        rb.drag = glissementGlissante;
    }

    private void OnTriggerExit(Collider other)
    {
        //rb.Remove(other.gameObject.GetComponent<Rigidbody>());
        rb = other.gameObject.GetComponent<Rigidbody>();

        rb.drag = glissementBase;
    }
}
