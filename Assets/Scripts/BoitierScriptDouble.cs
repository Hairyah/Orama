using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoitierScriptDouble : MonoBehaviour
{
    //bool isActivate = false;
    public GameObject spotFusible;
    public bool hasPower = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible")
        {
            hasPower = true;

            other.transform.position = spotFusible.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fusible")
        {
            hasPower = false ;
        }
    }
}
