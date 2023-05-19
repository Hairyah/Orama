using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeImpactCameraJoke : MonoBehaviour
{
    public GameObject cameraRotate;
    public Vector3 rotationDirection = new Vector3();
    public Animator joueurAnimator;

    private void OnCollisionEnter(Collision collision)
    {
        float valeurRotation = collision.relativeVelocity.magnitude / 2.0f;
        var truc = Random.Range(-1, 3);

        if (collision.gameObject.tag == "Joueur")
        {
            joueurAnimator.SetTrigger("AnimationCognerMur");
        }

        FindObjectOfType<AudioManager>().Play("ImpactCam");

        if (truc <= 0)
        {
            rotationDirection.z = -1;
        }
        else
        {
            rotationDirection.z = 1;
        }

        cameraRotate.transform.Rotate(valeurRotation * rotationDirection);
    }
}
