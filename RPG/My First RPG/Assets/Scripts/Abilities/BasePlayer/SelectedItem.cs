using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectedItem : MonoBehaviour {

    private Text selectedItemText;
    private List<BaseItem> playerInventory;

	// Use this for initialization
	void Start () {
        selectedItemText = GameObject.Find("SelectedItemText").GetComponent<Text>();
        PlayerInventory playerInventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
       // playerInventory = playerInventoryScript.ReturnPlayerInventory();
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void ShowSelectedItemText()
    {
        if(this.gameObject.GetComponent<Toggle>().isOn)
        {
            if(this.gameObject.name == "Empty")
            {
                selectedItemText.text = "This Slot is Empty"; 
            }
            else
            {
                selectedItemText.text = playerInventory[System.Int32.Parse(this.gameObject.name)].ItemName + "  " + playerInventory[System.Int32.Parse(this.gameObject.name)].Stamina;
                //playerinventory[1]
            }
        }
    }
}
