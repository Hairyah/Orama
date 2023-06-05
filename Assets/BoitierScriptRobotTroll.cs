using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoitierScriptRobotTroll : MonoBehaviour
{
    [Header("Fusible et Joueur")]
    public GameObject spotFusible;
    public GameObject particle;
    public PlayerMovement player;
    AudioSource audioSource;
    public GameObject fusible;

    [Header("Porte et animation")]
    public Animator robotShowWay;
    public Animator faussePorte;
    public AudioSource porteAudioSource;
    public GameObject particleFumee;



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

            if (robotShowWay != null)
            {
                robotShowWay.SetBool("isActivate", true);
            }

            faussePorte.SetTrigger("FausseOuverture");
            particleFumee.SetActive(true);
            porteAudioSource.Play();
            player.DegrapInsert();

            other.transform.position = spotFusible.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fusible")
        {
            if (robotShowWay!=null){
                robotShowWay.SetBool("isActivate", false);
            }
        }
    }
}
