using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropQuests : MonoBehaviour {
    InvetoryR inventoryR;
    Item item;
    ItemDatabase database;
    GameObject questCompleteNpc;
    bool isInInventory;
    bool isInit;
    Interactions interactions;
    int amount;
	// Update is called once per frame
	void Start () {
        isInit = false;
        isInInventory = false;
        inventoryR = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InvetoryR>();
        database = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDatabase>();
        interactions = gameObject.GetComponent<Interactions>();
	}
    private void Update()
    {   if(isInit)
        isInInventory = inventoryR.CheckIfItemIsInInventory(item);
        if(isInInventory && interactions.isNear && Input.GetKeyDown(KeyCode.Z))
        {
            // I have to find the index and get rid of it
            inventoryR.GetRidOfIemsAndAmount(item, amount); 
            interactions.questText.SetActive(true);
            interactions.questText.GetComponentInChildren<Text>().text = " Thank you for finding my Item!";
            interactions.CompletedQuest();
            item = null;
            isInInventory = false;
            isInit = false;
        }
    }
    // Have to add amounts
    public void ItemToFind(int id, GameObject npc, int number)
    {
        item = database.FetchItemByID(id);
        npc = questCompleteNpc;
        isInit = true;
        amount = number;
    }
}
