using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyCam : MonoBehaviour
{
    bool isActivate = false;
    public CinemachineVirtualCamera buddyCamera;

    public void buddyCamInteraction()
    {
        if (!isActivate)
        {
            isActivate = true;
            buddyCamera.Priority = 10;
        } else if (isActivate)
        {
            isActivate = false;
            buddyCamera.Priority = 0;
        }
    }
}
