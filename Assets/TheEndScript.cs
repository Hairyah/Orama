using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndScript : MonoBehaviour
{
    public GameObject endGame;

    public GameObject texteFIN;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Joueur")
        {
            endGame.SetActive(true);

            StartCoroutine(texte());
        }
    }

    IEnumerator texte()
    {
        yield return new WaitForSeconds(5f);

        texteFIN.SetActive(true);
    }
}
