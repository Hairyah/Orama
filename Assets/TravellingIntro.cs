using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingIntro : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float offset;
    public GameObject joueur;
    

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= minDistance && transform.position.z <= maxDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, joueur.transform.position.z - offset);
            Debug.Log("TRANSFORMATION0");
        }

        Debug.Log("Min distance : " + minDistance + "Max distance : " + maxDistance + "Min distance : " + transform.position.z);
    }
}
