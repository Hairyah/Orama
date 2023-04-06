using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Controler")]
    PlayerControls input;
    float leftStickAxis;
    float rightStickAxis;
    bool movementPressed;
    bool rotationPressed;
    bool grapPressed;
    bool buddyCamPressed;

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
    public GameObject grapPosition;

    [Header("Danger")]
    bool isDetected = false;
    float niveauAlerte;

    [Header("Buddy Cam Parameters")]
    public BuddyCam buddyCam;

    private void Awake()
    {
        input = new PlayerControls();

        input.Gameplay.Move.performed += ctx =>
        {
            leftStickAxis = ctx.ReadValue<float>();
            movementPressed = leftStickAxis != 0;
        };
        input.Gameplay.Rotate.performed += ctx =>
        {
            rightStickAxis = ctx.ReadValue<float>();
            rotationPressed = rightStickAxis != 0;
        };
        //input.Gameplay.Grap.performed += ctx => grapPressed = ctx.ReadValueAsButton();
        //input.Gameplay.BuddyCam.performed += ctx => buddyCamPressed = ctx.ReadValueAsButton();
    }

    void Update()
    {
        Debug.Log(rotationPressed);


        grapPressed = input.Gameplay.Grap.triggered;
        buddyCamPressed = input.Gameplay.BuddyCam.triggered;

        // PARTIE MOUVEMENT
        playerRigidbody.velocity += transform.forward * leftStickAxis * playerSpeed * Time.deltaTime;
        newRotation += (rightStickAxis * playerRotation * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, newRotation, 0);

        // PARTIE INTERACTION
        if (!isCarying && grapPressed)
        {
            interaction.enabled = true;
        } else if (isCarying && grapPressed)
        {
            DegrapInsert();
        }

        // PARTIE DETECTION
        if (isDetected)
        {
            niveauAlerte += 0.5f;
            Debug.Log(niveauAlerte);
        } else if (!isDetected && niveauAlerte > 0)
        {
            niveauAlerte -= 0.05f;
            Debug.Log(niveauAlerte);
        }

        if (buddyCamPressed)
        {
            buddyCam.buddyCamInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible" || other.tag == "Grappable")
        {
            grappedObject = other.gameObject;
            //float dist = Vector3.Distance(transform.position, other.transform.position);

            other.GetComponent<Rigidbody>().isKinematic = true;
            //other.GetComponent<BoxCollider>().enabled = false;
            other.transform.parent = transform;

            isCarying = true;
            //other.transform.position += new Vector3(0,0.5f,0);
            other.transform.position = grapPosition.transform.position;

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

    public void DegrapInsert()
    {
        isCarying = false;
        grappedObject.GetComponent<Rigidbody>().isKinematic = false;
        grappedObject.transform.parent = null;
        grappedObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnEnable()
    {
        input.Gameplay.Enable();
    }

    private void OnDisable()
    {
        input.Gameplay.Disable();
    }
}
