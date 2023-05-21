using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCollisionActivation : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Joueur")
        {
            Destroy(GetComponent<Animator>());
        }
    }
}