using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : MonoBehaviour {
    public Texture2D picture;
    NewActionBarScript skill;
    public int abilityCost = 10;
    public KeyCode key;
    bool isSet = false;
	// Use this for initialization
	void Start () {
        skill = GameObject.FindGameObjectWithTag("Gui").GetComponent<NewActionBarScript>();


    }
	
	// Update is called once per frame
	void Update () {
        if (!isSet)
        {
        key = skill.skill[1].key;   
        isSet = true;
        }
        if(Input.GetKeyDown(key))
        {
            ActivateAbility();
        }
                                 
	}



    public void ActivateAbility()
    {
       // Debug.Log("LIGHTNING STRIKE");
        GameInformation.PlayerEnergy -= abilityCost;
    }
}

