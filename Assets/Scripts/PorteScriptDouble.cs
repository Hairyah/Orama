using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteScriptDouble : MonoBehaviour
{
    public BoitierScriptDouble _boitier1;
    public BoitierScriptDouble _boitier2;

    public bool isOpen = false;

    void Update()
    {
        if(_boitier1.hasPower && _boitier2.hasPower && !isOpen)
        {
            transform.position += new Vector3(0, 5f, 0);
            isOpen = true;
        }
    }
}
