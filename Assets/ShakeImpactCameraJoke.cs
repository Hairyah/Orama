using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeImpactCameraJoke : MonoBehaviour
{
    public GameObject cameraRotate;
    public Vector3 rotationDirection = new Vector3();

    private void OnCollisionEnter(Collision collision)
    {
        float valeurRotation = collision.relativeVelocity.magnitude / 2.0f;

        cameraRotate.transform.Rotate(valeurRotation * rotationDirection);

        Debug.Log("Impact ! + " + valeurRotation);
    }
}
