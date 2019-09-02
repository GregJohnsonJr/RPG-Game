using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
    private Item item;
    private string data;
    private GameObject toolTip;

    void Start()
    {
        toolTip = GameObject.Find("ToolTip");
        toolTip.SetActive(false);
    }
     void Update()
    {
        if(toolTip.activeSelf)
        {
           toolTip.transform.position = Input.mousePosition;

        }




    }

    public void Activate(Item item)
    {
        this.item = item;
        ContrusctDataString();
        toolTip.SetActive(true);
    }

    public void DeActivate()
    {
        toolTip.SetActive(false);

    }
    public void ContrusctDataString()
    {
        //Add item.category in the database and color for rarity
        if (item.Type == "Weapon")
        {
            data = "<color=#4283f4><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n\nAgility: " + item.Agility + "\nEndurance: " + item.Endurance + "\nStrength: " + item.Strength + "\nStamina: " + item.Stamina + "\nIntellect: " + item.Intellect + "\nMastery: " + item.Mastery + "\n ";
        }
        else
        {
            data = "<color=#4283f4><b>" + item.Title + "</b></color>\n\n" + item.Description;
        }
        toolTip.transform.GetChild(0).GetComponent<Text>().text = data;
       
    }
}
