using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Base Stat Player")]
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] float playerSpeed;
    [SerializeField] float playerRotation;
    [SerializeField] float newRotation;

    [Header("Interraction")]
    [SerializeField] Collider interaction;
    [SerializeField] GameObject player;
    [SerializeField] GameObject grappedObject;
    bool isCarying = false;
    bool isDetected = false;
    float niveauAlerte;


    void Update()
    {
        // PARTIE MOUVEMENT
        playerRigidbody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
        newRotation += (Input.GetAxis("Horizontal") * playerRotation * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, newRotation, 0);

        // PARTIE INTERACTION
        if (!isCarying && Input.GetKeyDown("e"))
        {
            interaction.enabled = true;
        } else if (isCarying && Input.GetKeyDown("e"))
        {
            DegrapInsert();
        }

        if (isDetected)
        {
            niveauAlerte += 0.1f;
            Debug.Log(niveauAlerte);
        }else if (!isDetected && niveauAlerte > 0)
        {
            niveauAlerte -= 0.05f;
            Debug.Log(niveauAlerte);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible")
        {
            grappedObject = other.gameObject;
            //float dist = Vector3.Distance(transform.position, other.transform.position);

            other.GetComponent<Rigidbody>().isKinematic = true;
            //other.GetComponent<BoxCollider>().enabled = false;
            other.transform.parent = transform;

            isCarying = true;
            other.transform.position += new Vector3(0,0.5f,0);

            interaction.enabled = false;
        }

        if (other.tag == "ZoneEnnemi")
        {
            isDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ZoneEnnemi")
        {
            isDetected = false;
        }
    }

    private void DegrapInsert()
    {
        isCarying = false;
        grappedObject.GetComponent<Rigidbody>().isKinematic = false;
        grappedObject.transform.parent = null;
        grappedObject.GetComponent<BoxCollider>().enabled = true;
    }
}
