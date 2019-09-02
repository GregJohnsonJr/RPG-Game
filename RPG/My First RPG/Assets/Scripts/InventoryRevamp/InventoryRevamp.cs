using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Opens up the inventory
/// </summary>
public class InventoryRevamp : MonoBehaviour {
    public GameObject inventoryWindow;
    bool isOpened = true;
    bool isEarly = true;
	// Use this for initialization
    
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        isOpened = false;

        if(isEarly)
        {
            inventoryWindow.SetActive(false);
            isEarly = false;
        }
		if(Input.GetKeyDown(KeyBinds.Instance.inventory)&& inventoryWindow.activeInHierarchy == false)
        {
            if (!isOpened)
            {
                inventoryWindow.SetActive(true);
                isOpened = true;
            }
        }
        if (Input.GetKeyDown(KeyBinds.Instance.inventory)&& inventoryWindow.activeInHierarchy == true )
        {
            if (!isOpened)
            {
                inventoryWindow.SetActive(false);
                isOpened = true;
            }
        }
	}
}
