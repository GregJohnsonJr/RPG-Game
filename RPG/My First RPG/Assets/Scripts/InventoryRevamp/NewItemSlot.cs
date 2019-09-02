using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewItemSlot : MonoBehaviour, IDropHandler
{
    public int id;
    private InvetoryR inv;


    // Use this for initialization
    void Start()
    {
        inv = GameObject.Find("InventoryData").GetComponent<InvetoryR>();

    }
    public void OnDrop(PointerEventData eventData)
    {

        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        Debug.Log(inv.items[id].ID);
        if (gameObject.tag == "Equip")
        {
            if (droppedItem.item.Type == this.gameObject.name && this.gameObject.transform.childCount == 0)
            {
                droppedItem.transform.SetParent(this.transform);
                inv.items[droppedItem.slot] = new Item();
                inv.items[id] = droppedItem.item;
                droppedItem.slot = id;
            }
            if (inv.items[id].ID > -1)
            {
                Transform oldItem = this.transform.GetChild(0);
                oldItem.GetComponent<ItemData>().slot = droppedItem.slot; //. Getter / setter in the future
                oldItem.transform.SetParent(inv.slots[droppedItem.slot].transform);
                oldItem.transform.position = inv.slots[droppedItem.slot].transform.position;
                droppedItem.slot = id;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.position = this.transform.position;
                inv.items[droppedItem.slot] = oldItem.GetComponent<ItemData>().item;
                inv.items[id] = droppedItem.item;
            }
        }
        else if (inv.items[id].ID == -1)
        {
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.slot = id;
        }
        else if (inv.items[id].ID > -1)
        {
            Transform oldItem = this.transform.GetChild(0);
            oldItem.GetComponent<ItemData>().slot = droppedItem.slot; //. Getter / setter in the future
            oldItem.transform.SetParent(inv.slots[droppedItem.slot].transform);
            oldItem.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slot] = oldItem.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }     
    }
}
