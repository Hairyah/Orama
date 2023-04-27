using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HautParleurScript : MonoBehaviour
{
    AudioClip audioClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude / 10.0f > 0.2)
        {
            audioSource.Stop();
            FindObjectOfType<AudioManager>().Play("BreakAudio");
        }
    }
}
