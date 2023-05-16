using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoitierScript : MonoBehaviour
{
    [Header("Fusible et Joueur")]
    public GameObject spotFusible;
    public GameObject particle;
    public PlayerMovement player;
    AudioSource audioSource;

    [Header("Porte et animation")]
    public Animator porteAnimator;
    public MeshRenderer ecran;
    public Material rougeFerme;
    public Material vertOuvert;
    public AudioSource porteAudioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(audioSource.clip, 0.4f);

            //porte.transform.position += new Vector3(0, 5f, 0);
            porteAnimator.SetBool("IsClose", false);
            ecran.material = vertOuvert;

            player.DegrapInsert();

            other.transform.position = spotFusible.transform.position;

            porteAudioSource.PlayOneShot(porteAudioSource.clip, 0.6f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fusible")
        {
            //porte.transform.position -= new Vector3(0, 5f, 0);
            porteAnimator.SetBool("IsClose", true);
            ecran.material = rougeFerme;
        }
    }
}
