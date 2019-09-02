using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    public string name;
    public Text dial;
    Interactions inter;
    bool isDialogue;
	// Use this for initialization
	void Start () {
        isDialogue = false;
        dial.enabled = false;
        name = gameObject.name;
        inter = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactions>();
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown("z"))
        {
            DetermindTheNPC();
        }
        if(inter.isNpcNear == false)
        {
            dial.enabled = false;
        }
        if(isDialogue && inter.isNpcNear)
        {

            dial.enabled = true;
        }*/
      
	}

   public void DetermindTheNPC()
    {
      

    }
}
