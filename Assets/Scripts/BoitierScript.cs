using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoitierScript : MonoBehaviour
{
    //bool isActivate = false;
    public GameObject porte;
    public GameObject spotFusible;
    public GameObject particle;
    public PlayerMovement player;
    AudioSource audioSource;

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

            Debug.Log(porte);
            porte.transform.position += new Vector3(0, 5f, 0);

            player.DegrapInsert();

            other.transform.position = spotFusible.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fusible")
        {
            porte.transform.position -= new Vector3(0, 5f, 0);
        }
    }
}
