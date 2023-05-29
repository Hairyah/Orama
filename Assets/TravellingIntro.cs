using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingIntro : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float offset;
    public GameObject joueur;
    public CinemachineVirtualCamera travellingCam;

    public bool travellingStated;
    public bool hasBeenActived;

    // Update is called once per frame
    void Update()
    {
        var distanceBetween = joueur.transform.position.z - transform.position.z;
        if (distanceBetween > -8)
        {
            travellingStated = true;
        }
        if (transform.position.z <= maxDistance && travellingStated)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, joueur.transform.position.z - offset);
        }
        if (travellingCam.m_Lens.FieldOfView < 50f && travellingStated)
        {
            travellingCam.m_Lens.FieldOfView += (3f * Time.deltaTime);
        }
    }
}
