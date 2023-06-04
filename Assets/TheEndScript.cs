using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndScript : MonoBehaviour
{
    public GameObject endGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Joueur")
        {
            endGame.SetActive(true);
        }
    }
}
