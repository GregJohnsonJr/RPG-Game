using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour {
    public string playerTag;
	// Use this for initialization
	void Start () {
		
	}	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,
           transform.position - GameObject.FindGameObjectWithTag(playerTag).transform.position, 10 * Time.deltaTime, 0.0f));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
       // transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag(playerTag).transform.eulerAngles.x, 
         //   GameObject.FindGameObjectWithTag(playerTag).transform.eulerAngles.y, 
        //    GameObject.FindGameObjectWithTag(playerTag).transform.eulerAngles.z + 90f));
	}
}
