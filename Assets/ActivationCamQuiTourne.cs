using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationCamQuiTourne : MonoBehaviour
{
    public CameraTournanteRelou camTournante;
    public AudioSource discoMusic;
    bool hasAlreadyEntered=false;
    public GameObject ATH1;
    public GameObject ATHDisco;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Joueur")
        {
            if (!hasAlreadyEntered)
            {
                hasAlreadyEntered = true;
                discoMusic.PlayOneShot(discoMusic.clip, 0.6f);
            }
            StartCoroutine(ActivationRotate());
            ATH1.SetActive(false);
            ATHDisco.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Joueur")
        {
            ATH1.SetActive(true);
            ATHDisco.SetActive(false);
        }
    }

    IEnumerator ActivationRotate()
    {
        yield return new WaitForSeconds(1.5f);

        camTournante.playerHasEnter = true;
    }
}
