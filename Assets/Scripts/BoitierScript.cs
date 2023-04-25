using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoitierScript : MonoBehaviour
{
    //bool isActivate = false;
    public GameObject porte;
    public GameObject spotFusible;

    public PlayerMovement player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible")
        {
            Debug.Log("OUVERTURE PORTE");
            //isActivate = true;

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
            Debug.Log("FERMETURE PORTE");
            //isActivate = false;

            porte.transform.position -= new Vector3(0, 5f, 0);
        }
    }
}
