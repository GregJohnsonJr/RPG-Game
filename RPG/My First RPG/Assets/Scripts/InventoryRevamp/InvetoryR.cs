using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryR : MonoBehaviour
{


    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    GameObject[] equipSlots;
    ItemData itemDataStorage;
    [HideInInspector]
    public GameObject drops;

    void Start()
    {
        drops = GameObject.Find("Drops");
        drops.SetActive(false);
        equipSlots = GameObject.FindGameObjectsWithTag("Equip");
        database = GetComponent<ItemDatabase>();
        slotAmount = 20 + equipSlots.Length;
        inventoryPanel = GameObject.Find("InventoryWindow");
        slotPanel = inventoryPanel.transform.Find("Panel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            if (i > 19)
            {
                //- 20  because that is teh amount in the inventory. ill have to modify it later if we add inventory expanisons etc.
                items.Add(new Item());
                equipSlots[i - 20].AddComponent<NewItemSlot>();
                equipSlots[i - 20].GetComponent<NewItemSlot>().id = i;
                slots.Add(equipSlots[i - 20]);
                continue;
            }

            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<NewItemSlot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
        //When you add items, you have to add components to them
        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(1);
        AddItem(2);
        AddItem(2);
        Debug.Log(items[1].Title);
    }
    public void AddItemForDrops(int id, int amount, GameObject dropPouch)
    {
        //drops.SetActive(true);
        Item[] itemtoAdd = new Item[amount];
        for (int i = 0; i < amount; i++)
        {
            itemtoAdd[i] = database.FetchItemByID(id);
        }
        GameObject tempDrops = Instantiate(drops);
        tempDrops.SetActive(true);
        tempDrops.transform.SetParent(drops.transform.parent);
        tempDrops.transform.position = drops.transform.position;
        dropPouch.GetComponent<EnemyDrops>().dropInventory = tempDrops;

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Drops");
        GameObject parent = tempDrops;
       
        for (int i = 0; i < amount; i++)
        {

            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            if (items[i+slotAmount] == null)
            {
                items[i+slotAmount] = new Item();
            }
            if(slots[i+slotAmount] == null)
            {
                slots[i + slotAmount] = Instantiate(inventorySlot);
            }
            slots[i + slotAmount].GetComponent<NewItemSlot>().id = i + slotAmount;
            slots[i + slotAmount].transform.SetParent(parent.transform);
        }


        for (int i = slotAmount; i < amount + slotAmount; i++)
        {


            if (itemtoAdd[i - slotAmount].Stackable && CheckIfItemIsInDrops(itemtoAdd[i - slotAmount]))
            {
                for (int j = slotAmount; j < amount + slotAmount; j++)
                {
                    if (items[j].ID == id)
                    {
                        ItemData data = slots[slotAmount].transform.GetChild(0).GetComponent<ItemData>();
                        data.amount++;
                        
                        RectTransform rt = data.transform.GetChild(0).GetComponent(typeof(RectTransform)) as RectTransform;
                        rt.sizeDelta = new Vector2(21f, rt.rect.height);
                        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                        break;
                        //Debug.Log(data.amount.ToString());
                    }
                }                 
            }
            else if (items[i].ID == -1)
            {
                // THis is how you add items btw
                items[i] = itemtoAdd[i - slotAmount];
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemtoAdd[i - slotAmount];
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.GetComponent<ItemData>().amount = 1;
                itemObj.transform.SetParent(slots[i].transform);
                //itemObj.transform.position = slots[i].transform.position;
                itemObj.GetComponent<Image>().sprite = itemtoAdd[i - slotAmount].Sprite;
                itemObj.name = itemtoAdd[i - slotAmount].Title;
            }
        }


           
        
        for (int i = (slotAmount + amount)-1; i > slotAmount-1; i--)
        {
            if (slots[i].transform.childCount <= 0)
            {
                Destroy(slots[i]);
                slots.RemoveAt(i);
                items.RemoveAt(i);
                //slots[i + 1].GetComponent<ItemData>().slot = i;
            }
        }
        tempDrops.GetComponent<DestroyDropMenu>().master = false;
        // Need a way to disable the loot menu when the loot is moved, (maybe a range) <- Done and i think getting rid of it is as well
        // Need a way to get the loot on there and fuse it together when many mobs die in the same area- To do list for tommorrow morning
    }

    public void AddItem(int id)
    {

        Item itemtoAdd = database.FetchItemByID(id);

        if (itemtoAdd.Stackable && CheckIfItemIsInInventory(itemtoAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    RectTransform rt = data.transform.GetChild(0).GetComponent(typeof(RectTransform)) as RectTransform;
                    rt.sizeDelta = new Vector2(21f, rt.rect.height);
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                    //Debug.Log(data.amount.ToString());
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    // THis is how you add items btw
                    items[i] = itemtoAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemtoAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.GetComponent<ItemData>().amount = 1;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.GetComponent<Image>().sprite = itemtoAdd.Sprite;
                    itemObj.name = itemtoAdd.Title;
                    break;
                }
            }

        }
    }
    public void AddItemToSlot(int id, int slot)
    {

        Item itemtoAdd = database.FetchItemByID(id);

        if (itemtoAdd.Stackable && CheckIfItemIsInInventory(itemtoAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                    //Debug.Log(data.amount.ToString());
                }
            }
        }
        else
        {
            if (items[slot].ID == -1)
            {
                items[slot] = itemtoAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemtoAdd;
                itemObj.GetComponent<ItemData>().slot = slot;
                itemObj.GetComponent<ItemData>().amount = 1;
                itemObj.transform.SetParent(slots[slot].transform);
                itemObj.transform.position = slots[slot].transform.position;
                itemObj.GetComponent<Image>().sprite = itemtoAdd.Sprite;
                itemObj.name = itemtoAdd.Title;
            }
        }
    }
    public bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }

        return false;
    }
    bool CheckIfItemIsInDrops(Item item)
    {
        for (int i = slotAmount; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }

        return false;
    }
    public void GetRidOfIemsAndAmount(Item item, int amount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(amount <= 0)
            {
                break;
            }
            if (items[i].ID == item.ID)
            {
                ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                if(data.amount > amount)
                {
                    data.amount -= amount;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    amount = 0;
                    break;
                }
                else if(data.amount < amount)
                {
                    int j = 0;
                    //amount-=data.amount;
                    while(amount > 0 && j < items.Count)
                    {
                        if(items[j] != null && items[j].ID == item.ID )
                        {
                            
                            data = slots[j].transform.GetChild(0).GetComponent<ItemData>();
                            if (data)
                            {
                                if (amount < data.amount)
                                {
                                    data.amount -= amount;
                                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                                    Debug.Log(data.gameObject);
                                    Debug.Log(data.amount);
                                    amount = 0;
                                    break;
                                }
                                else if (amount > data.amount)
                                {
                                    amount -= data.amount;
                                    Destroy(data.gameObject);
                                    
                                }
                            }
                        }
                        j++;
                    }
                }
            }
                
        }
    }

}
