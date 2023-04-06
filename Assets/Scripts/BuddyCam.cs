using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyCam : MonoBehaviour
{
    bool isActivate = false;
    public CinemachineVirtualCamera buddyCamera;

    void Update()
    {
        if (!isActivate && Input.GetButtonDown("BuddyCam"))
        {
            isActivate = true;
            buddyCamera.Priority = 10;
        } else if (isActivate && Input.GetButtonDown("BuddyCam"))
        {
            isActivate = false;
            buddyCamera.Priority = 0;
        }
    }
}
