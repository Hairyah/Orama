using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonCartonCollision : MonoBehaviour
{
    AudioClip audioClip;
    AudioSource audioSource;

    public AudioClip[] audioClipsTest;

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

        var nbAudio = Random.Range(0, audioClipsTest.Length-1);

        audioSource.PlayOneShot(audioClipsTest[nbAudio], audioLevel);
    }
}
