using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBeamAttack : MonoBehaviour {
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
    void Update() {
        if (!isSet)
        {
            key = skill.skill[2].key;
            isSet = true;
        }
        if (Input.GetKeyDown(key))
        {
            ActivateAbility();

        }
	}

    public void ActivateAbility()
    {
       // Debug.Log("PLASMA WAVE");
        GameInformation.PlayerEnergy -= abilityCost;

    }
}
