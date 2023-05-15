using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTournanteRelou : MonoBehaviour
{
    public float valeurRotation;
    public Vector3 rotationDirection = new Vector3();

    void Update()
    {
        transform.Rotate(valeurRotation * rotationDirection * Time.deltaTime);
    }
}
