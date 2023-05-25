using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public float forceFactor = 200f;
    public float ejectFactor = 200f;
    public bool isActived = false;
    public bool isShockWave = false;
    public GameObject player;
    public bool isPrincipal;

    List<Rigidbody> rgBalls = new List<Rigidbody>();

    Transform magnetP;

    void Start()
    {
        magnetP = GetComponent<Transform>();
        isShockWave = false;
    }

    private void Update()
    {
        if (isPrincipal)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2,player.transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (isActived)
        {
            foreach (Rigidbody rgBall in rgBalls)
            {
                if (isShockWave)
                {
                    rgBall.AddForce((magnetP.position + rgBall.position) * ejectFactor * Time.fixedDeltaTime);
                }
                else
                {
                    rgBall.AddForce((magnetP.position - rgBall.position) * forceFactor * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fusible" || other.tag == "PotHuile" || other.tag == "BuddyCam" || other.tag == "Grappable")
        {
            rgBalls.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fusible" || other.tag == "PotHuile" || other.tag == "BuddyCam" || other.tag == "Grappable")
        {
            rgBalls.Remove(other.GetComponent<Rigidbody>());
        }
    }
}