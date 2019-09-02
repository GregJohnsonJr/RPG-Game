using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStateButtons : MonoBehaviour {
    public GameObject[] buttons;
	// Use this for initialization
	void Start () {
        DeActiveButtons();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Summon"))
        {
            ActiveButtons();
        }
        else
            DeActiveButtons();
            
	}
    void ActiveButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }
    void DeActiveButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
