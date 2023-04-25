using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    public MagnetScript _magnetScript;
    public MagnetScript _magnetScript2;

    [Header("Danger")]
    bool isDetected = false;
    float niveauAlerte;

    [Header("Buddy Cam Parameters")]
    public BuddyCam buddyCam;

    AudioSource audioSource;

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

        input.Gameplay.Move.canceled += ctx => leftStickAxis = 0;
        input.Gameplay.Rotate.canceled += ctx => rightStickAxis = 0;

        //input.Gameplay.Grap.performed += ctx => grapPressed = ctx.ReadValueAsButton();
        //input.Gameplay.BuddyCam.performed += ctx => buddyCamPressed = ctx.ReadValueAsButton();
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        grapPressed = input.Gameplay.Grap.triggered;
        buddyCamPressed = input.Gameplay.BuddyCam.triggered;

        // PARTIE MOUVEMENT
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            playerRigidbody.velocity += transform.forward * leftStickAxis * playerSpeed * Time.deltaTime;
            newRotation += (rightStickAxis * playerRotation * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, newRotation, 0);
        }
        else
        {
            playerRigidbody.velocity += transform.forward * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
            newRotation += (Input.GetAxisRaw("Horizontal") * playerRotation * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, newRotation, 0);
        }

        // PARTIE INTERACTION
        if (!_magnetScript.isActived && (grapPressed || Input.GetKeyDown(KeyCode.E)))
        {
            interaction.enabled = true;
            _magnetScript.isActived = true;
            _magnetScript2.isActived = true;
            audioSource.PlayOneShot(audioSource.clip, 0.65f);
        } else if (_magnetScript.isActived && (grapPressed || Input.GetKeyDown(KeyCode.E)))
        {
            DegrapInsert();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _magnetScript.isShockWave = !_magnetScript.isShockWave;
            _magnetScript2.isShockWave = !_magnetScript2.isShockWave;
        }

        // PARTIE DETECTION
        if (isDetected)
        {
            niveauAlerte += 0.5f;
            if (niveauAlerte > 30)
            {
                Debug.Log("PERDU !");
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }
            Debug.Log(niveauAlerte);
        } else if (!isDetected && niveauAlerte > 0)
        {
            niveauAlerte -= 0.05f;
        }

        if (buddyCamPressed || Input.GetKeyDown(KeyCode.Space))
        {
            buddyCam.buddyCamInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible")
        {
            /*if (gameObject.GetComponent<FixedJoint>() == null)
            {
                other.transform.position = grapPosition.transform.position;

                var joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = other.attachedRigidbody;

                isCarying = true;
            }*/
            FindObjectOfType<AudioManager>().Play("Grap");

            grappedObject = other.gameObject;

            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.parent = transform;

            isCarying = true;
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
        _magnetScript.isActived = false;
        _magnetScript2.isActived = false;
        interaction.enabled = false;

        audioSource.Stop();

        isCarying = false;
        /*Destroy(gameObject.GetComponent<FixedJoint>());
        Debug.Log("Destroyed");*/
        if(grappedObject != null)
        {
            grappedObject.GetComponent<Rigidbody>().isKinematic = false;
            grappedObject.transform.parent = null;
            grappedObject.GetComponent<BoxCollider>().enabled = true;
        }
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
