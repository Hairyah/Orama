using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationGame : MonoBehaviour
{
    public GameObject ATH;
    public PlayerMovement playerMov;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Joueur")
        {
            playerMov.murStartBroken = true;
            ATH.gameObject.SetActive(true);
        }
    }
}
