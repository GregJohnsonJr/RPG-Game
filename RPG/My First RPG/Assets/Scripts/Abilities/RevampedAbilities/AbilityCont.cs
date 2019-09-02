using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiliyCont : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CheckForObjectsInFront();
    }
    void CheckForObjectsInFront()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.transform.gameObject.name == "Terrain")
            {
                float dist = Vector3.Distance(transform.position, hit.point);
                if(dist <= 1f)
                {
                    //transform.position += new Vector3(0, .5f*(5/dist)); We are going to destroy it instead for now
                    Destroy(gameObject);
                }
            }
        }
    }
   
}
