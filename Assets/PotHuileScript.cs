using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHuileScript : MonoBehaviour
{

    public GameObject zoneHuile;
    public Vector3 anciennePos;

    private void Start()
    {
        anciennePos = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if((transform.position.x < anciennePos.x - 2 || transform.position.x > anciennePos.x + 2) || (transform.position.z < anciennePos.z - 2 || transform.position.z > anciennePos.z + 2))
        {
            anciennePos = transform.position;

            Instantiate(zoneHuile, new Vector3(transform.position.x, -0.07f, transform.position.z),Quaternion.identity);
        }
    }
}
