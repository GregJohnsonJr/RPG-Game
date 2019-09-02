using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelStats : MonoBehaviour {
    public GameObject[] charStats;
    public GameObject characterPanel;
    GameObject keyBind;
    bool isBusy;
    bool isOpened;
	// Use this for initialization
	void Start () {
            keyBind = GameObject.FindGameObjectWithTag("KeyBinds");               
	}
	
	// Update is called once per frame
	void Update () {
        isBusy = keyBind.GetComponent<KeyBindChanger>().isPopUp;
        Debug.Log(isBusy);
        isOpened = false;
        if (Input.GetKeyDown(KeyBinds.Instance.character) && characterPanel.activeInHierarchy == false && !isBusy)
        {
          
            if (!isOpened)
            {              
                UpdateStatsWhenOpened();
                characterPanel.SetActive(true);
                isOpened = true;
            }
        }
        else if (Input.GetKeyDown(KeyBinds.Instance.character) && characterPanel.activeInHierarchy == true)
        {
            if (!isOpened)
            {
                characterPanel.SetActive(false);
                isOpened = true;
            }
        }

    }
    //Add hover events to show what they effect
    void UpdateStatsWhenOpened()
    {
        for (int i = 0; i < charStats.Length; i++)
        {
            if(charStats[i].name == "Stamina")
            {
                charStats[i].GetComponent<Text>().text = "Stamina: " + GameInformation.Stamina;
            }
            else if (charStats[i].name == "Intellect")
            {
                charStats[i].GetComponent<Text>().text = "Intellect: " + GameInformation.Intellect;
            }
            else if (charStats[i].name == "Endurance")
            {
                charStats[i].GetComponent<Text>().text = "Endurance: " + GameInformation.Endurance;
            }
            else if (charStats[i].name == "Strength")
            {
                charStats[i].GetComponent<Text>().text = "Strength: " + GameInformation.Strength;
            }
            else if (charStats[i].name == "Agility")
            {
                charStats[i].GetComponent<Text>().text = "Agility: " + GameInformation.Agility;
            }
            else if (charStats[i].name == "Resistance")
            {
                charStats[i].GetComponent<Text>().text = "Resistance: " + GameInformation.Resistance;
            }
            else if (charStats[i].name == "Mastery")
            {
                charStats[i].GetComponent<Text>().text = "Mastery: " + GameInformation.Mastery;
            }
            else if (charStats[i].name == "PlayerName")
            {
                charStats[i].GetComponent<Text>().text = "Name: " + GameInformation.PlayerName;
            }
            else if (charStats[i].name == "PlayerLevel")
            {
                charStats[i].GetComponent<Text>().text = "Level: " + GameInformation.PlayerLevel;
            }
        }
    }
}
