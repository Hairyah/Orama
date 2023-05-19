using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationCamQuiTourne : MonoBehaviour
{
    public CameraTournanteRelou camTournante;
    public AudioSource discoMusic;
    bool hasAlreadyEntered=false;

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
        }
    }

    IEnumerator ActivationRotate()
    {
        yield return new WaitForSeconds(1.5f);

        camTournante.playerHasEnter = true;
    }
}
