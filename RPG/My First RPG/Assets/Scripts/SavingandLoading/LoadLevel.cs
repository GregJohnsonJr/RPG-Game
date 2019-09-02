using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    LevelLoader level;
   
	// Use this for initialization
	void Start () {
        gameObject.AddComponent<LevelLoader>();
        level = gameObject.GetComponent<LevelLoader>();
        level.LoadLevel(2);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
