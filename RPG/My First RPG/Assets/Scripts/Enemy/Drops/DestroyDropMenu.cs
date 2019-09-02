using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDropMenu : MonoBehaviour {
    public bool master;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!master)
        {
            if(!gameObject.GetComponentInChildren<ItemData>())
            {
                Destroy(this.gameObject);
            }
        }
	}
}
