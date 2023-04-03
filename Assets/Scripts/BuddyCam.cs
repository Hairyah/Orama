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
        if (!isActivate && Input.GetKeyDown("space"))
        {
            isActivate = true;
            buddyCamera.Priority = 10;
        } else if (isActivate && Input.GetKeyDown("space"))
        {
            isActivate = false;
            buddyCamera.Priority = 0;
        }
    }
}
