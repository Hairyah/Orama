using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTournanteRelou : MonoBehaviour
{
    public float valeurRotation;
    public Vector3 rotationDirection = new Vector3();
    public bool playerHasEnter;

    public Animator RobotDancer;
    public Animator RobotWall;

    private void Awake()
    {
        RobotDancer.SetTrigger("RobotDancer");
        RobotWall.SetTrigger("RobotWall");
    }

    void Update()
    {
        if (playerHasEnter)
        {
            transform.Rotate(valeurRotation * rotationDirection * Time.deltaTime);
        }
    }
}
