using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class KeyBindsController : MonoBehaviour {

    public GameObject escapeWindow;
    bool isOpened = true;
    bool isEarly = true;


    // Update is called once per frame
    void Update()
    {
        isOpened = false;

        if (isEarly)
        {
            escapeWindow.SetActive(false);
            isEarly = false;
        }
        if (Input.GetKeyDown(KeyBinds.Instance.escape) && escapeWindow.activeInHierarchy == false)
        {
            if (!isOpened)
            {
                escapeWindow.SetActive(true);
                isOpened = true;
                ChangeKeyBinds();
            }
        }
        if (Input.GetKeyDown(KeyBinds.Instance.escape) && escapeWindow.activeInHierarchy == true)
        {
            if (!isOpened)
            {
                escapeWindow.SetActive(false);
                isOpened = true;
            }
        }
    }
    public void ChangeKeyBinds()
    {
        // I just gotta type it out, ill do that later.
        // We are going to add text to buttons, and make it so that when you click that button it changes that specific keybind with respect to the name of the objcet.
        // Shouldnt be too hard, but will take a min. Going to use tags
        GameObject[] temp = GameObject.FindGameObjectsWithTag("KeyBinds");
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].name == "InventoryKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Inventory: " + KeyBinds.Instance.inventory + "\n";
            }
            else if (temp[i].name == "CharacterKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Character Stats: " + KeyBinds.Instance.character + "\n";
            }
            else if (temp[i].name == "SkillKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Skills: " + KeyBinds.Instance.skills + "\n";
            }
            else if (temp[i].name == "MapKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Map: " + KeyBinds.Instance.map + "\n";
            }
            else if (temp[i].name == "QuestKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Quest: " + KeyBinds.Instance.quest + "\n";
            }
            else if (temp[i].name == "PetKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Pets: " + KeyBinds.Instance.pets + "\n";
            }
            else if (temp[i].name == "EquipKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Equipment: " + KeyBinds.Instance.equip + "\n";
            }
            else if (temp[i].name == "EscapeKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Escape Window: " + KeyBinds.Instance.escape + "\n";
            }
            else if (temp[i].name == "GuildKey")
            {
                temp[i].GetComponentInChildren<Text>().text = "Guild: " + KeyBinds.Instance.guild + "\n";
            }
            else if (temp[i].name == "Ability1")
            {
                string temp1 = KeyBinds.Instance.Abilitiy1.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability1: " + temp2 + "\n";
            }
            else if (temp[i].name == "Ability2")
            {
                string temp1 = KeyBinds.Instance.Ability2.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability2: " + temp2 + "\n";
            }
            else if (temp[i].name == "Ability3")
            {
                string temp1 = KeyBinds.Instance.Ability3.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability3: " + temp2 + "\n";
            }
            else if (temp[i].name == "Ability4")
            {
                string temp1 = KeyBinds.Instance.Ability4.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability4: " + temp2 + "\n";
            }
            else if (temp[i].name == "Ability5")
            {
                string temp1 = KeyBinds.Instance.Ability5.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability5: " + temp2 + "\n";
            }
            else if (temp[i].name == "Ability6")
            {
                string temp1 = KeyBinds.Instance.Ability6.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability6: " + temp2 + "\n";
            }
            else if (temp[i].name == "Ability7")
            {
                string temp1 = KeyBinds.Instance.Ability7.ToString();
                char temp2 = temp1[temp1.Length - 1];
                temp[i].GetComponentInChildren<Text>().text = "Ability7: " + temp2 + "\n";
            }
          
        }
        
        
    }
}
