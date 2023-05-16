using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float camPosY;
    private float camPosZ;

    private void Start()
    {
        camPosY = transform.position.y;
        camPosZ = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,camPosY,camPosZ);
    }
}
