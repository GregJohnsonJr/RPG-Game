using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour {
    public GameObject laserBeam;
    public GameObject player;
    bool setPos = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyBinds.Instance.Abilitiy1))
        {
            laserBeam.SetActive(true);
            //Change the scale with the range, have to figure out the scalar
            laserBeam.transform.localScale = new Vector3(laserBeam.transform.localScale.x, laserBeam.transform.localScale.y, 6);
            setPos = true;
        }
        if(setPos)
        {
            laserBeam.transform.position = player.transform.position; // + offset
        }
	}
}
