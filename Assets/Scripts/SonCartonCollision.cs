using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonCartonCollision : MonoBehaviour
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
        float audioLevel = collision.relativeVelocity.magnitude / 10.0f;

        if (audioLevel > 0.8)
        {
            audioLevel = 0.8f;
        }
        audioSource.PlayOneShot(audioClip, audioLevel);
    }
}
