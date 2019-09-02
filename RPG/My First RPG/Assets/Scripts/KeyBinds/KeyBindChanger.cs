using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBindChanger : MonoBehaviour {
    Button button;
    [HideInInspector]
    public bool isSelecting;
    public GameObject popUp;
    [HideInInspector]
    public bool isPopUp;
	// Use this for initialization
	void Start () {
        button = gameObject.GetComponent<Button>();
        isPopUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(isPopUp)
        {
            
            popUp.SetActive(true);
        }
        else
        {
            popUp.SetActive(false);
        }
        if (!isSelecting)
        {
            
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnClick);
        }
        else
        {
            GameObject[] tempBinds = GameObject.FindGameObjectsWithTag("KeyBinds");
            for (int i = 0; i < tempBinds.Length; i++)
            {
                tempBinds[i].GetComponent<KeyBindChanger>().isPopUp = true;
            }
            if(Input.anyKey)
            {
                string temp = (string)Input.inputString.ToUpper();
                if (temp != "")
                {
                    KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), temp);
                    ChangedKeyBasedOnName(key);
                }
            }
        }

    }
    void OnClick()
    {
        isSelecting = true;
    }
    void ChangedKeyBasedOnName(KeyCode newKey)
    {
        if (gameObject.name == "InventoryKey")
        {
            KeyBinds.Instance.ChangeInvKey(newKey);
        }
        else if (gameObject.name == "CharacterKey")
        {
            KeyBinds.Instance.ChangeCharacterKey(newKey);
        }
        else if (gameObject.name == "SkillKey")
        {
            KeyBinds.Instance.ChangeSkillKey(newKey);
        }
        else if (gameObject.name == "MapKey")
        {
            KeyBinds.Instance.ChangeMapKey(newKey);
        }
        else if (gameObject.name == "QuestKey")
        {
            KeyBinds.Instance.ChangeQuestKey(newKey);
        }
        else if (gameObject.name == "PetKey")
        {
            KeyBinds.Instance.ChangePetKey(newKey);
        }
        else if (gameObject.name == "EquipKey")
        {
            KeyBinds.Instance.ChangeEquipKey(newKey);
        }
        else if (gameObject.name == "EscapeKey")
        {
            KeyBinds.Instance.ChangeEscapeKey(newKey);
        }
        else if (gameObject.name == "GuildKey")
        {
            KeyBinds.Instance.ChangeGuildKey(newKey);
        }
        else if (gameObject.name == "Ability1")
        {
            KeyBinds.Instance.ChangeAbilityOneKey(newKey);
        }
        else if (gameObject.name == "Ability2")
        {
            KeyBinds.Instance.ChangeAbilityTwoKey(newKey);
        }
        else if (gameObject.name == "Ability3")
        {
            KeyBinds.Instance.ChangeAbilityThreeKey(newKey);
        }
        else if (gameObject.name == "Ability4")
        {
            KeyBinds.Instance.ChangAbilityFourKey(newKey);
        }
        else if (gameObject.name == "Ability5")
        {
            KeyBinds.Instance.ChangeAbilityFiveKey(newKey);
        }
        else if (gameObject.name == "Ability6")
        {
            KeyBinds.Instance.ChangeAbilitySixKey(newKey);
        }
        else if (gameObject.name == "Ability7")
        {
            KeyBinds.Instance.ChangeAbilitySevenKey(newKey);
        }
        GameObject[] tempBinds = GameObject.FindGameObjectsWithTag("KeyBinds");
        for (int i = 0; i < tempBinds.Length; i++)
        {
            tempBinds[i].GetComponent<KeyBindChanger>().isPopUp = false;
        }
        isSelecting = false;
        KeyBindsController temp;
        temp = GameObject.FindGameObjectWithTag("UiManager").GetComponent<KeyBindsController>();
        temp.ChangeKeyBinds();
    }
}
