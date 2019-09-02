using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class PlayerInventory : MonoBehaviour {
    /// <summary>
    ///  OVERHAUL THE SYSTEM MORE THEN LIKELY, WILL DO IT VERY SOON. AFTER CLASS???
    ///  OVER HAULED new inventory system is called revamped!
    /// </summary>
    public CreateNewEquipment newEquipment;
    public BaseItem item;
    public GameObject player;
    public BaseEquipment baseEquipment;
    public List<BaseItem> inventory;
    public List<BaseItem> inventoryCopy;
    public int counter = 0;
    public int p = 0;
    struct InventoryInfo
    {
        public int[] inventoryIdInfo;
        public string[] inventoryDesInfo;
        public BaseItem.ItemTypes[] inventoryItemInfo;
        public string[] inventoryItemName;
        public int[] inventoryItemAgility;
        public int[] inventoryItemIntellect;
        public int[] inventroyItemStrength;
        public int[] inventroyItemMastery;
        public int[] inventroyItemEndurance;
        public int[] inventroyItemStamina;
        public List<BaseItem> baseitemStruct;


    }

    InventoryInfo inventoryInfo;
    List<InventoryInfo> inventoryInfoList;
	// Use this for initialization
	void Start ()
    {
        //item = GetComponent<BaseItem>();
        inventoryInfo = new InventoryInfo();
        initializeStructs(inventoryInfo);
       // initializeList();
        inventoryCopy = new List<BaseItem>();
        inventory = new List<BaseItem>();
        //Have to fix the issue of the duplicating item creation!!!
       
        for (int i = 0; i < 10; i++)
        {
             
            newEquipment = gameObject.AddComponent<CreateNewEquipment>();
            //It is making everyone a duplicate of the newly created one interesting
            // Appears the class information is changing...interesting.
            // FIXED IT WITH STRUCT, NOW WE HAVE TO SET THE STRUCT EQUAL TO THE LIST SOON TO RESET VALUES;
            newEquipment.Start();
            item = GetComponent<BaseItem>();
            //inventoryInfo.baseitemStruct.Add(inventory[counter]);
            inventory.Add(item);
            AddEquipmentToStruct(counter);


            counter = i;
          
            
        }
        
        // Debug.Log(inventory[i].ItemID);
        //Debug.Log(inventory[i].ItemDescription);
        // Debug.Log(inventory[i].ItemName);
        // Debug.Log(inventory[i].Itemtypes);
        // Debug.Log(inventory[i].Agility);
        // Debug.Log(inventory[i].Intellect);
        // Debug.Log(inventory[i].Stamina);
        //  Debug.Log(inventory[i].Strength);
        //  Debug.Log(inventory[i].Mastery);
        //  Debug.Log(inventory[i].Endurance);

        
    }

    void AddEquipmentToStruct (int counter)
    {
        // NOW MAKE A FUNCTION TO SET THEM EQUAL TO THE LIST!  
        // this will be the struct function that adds all the items to the array list!
        
       // newEquipment = gameObject.AddComponent<CreateNewEquipment>();
        inventoryInfo.inventoryIdInfo[counter] = inventory[counter].ItemID;
        //inventoryInfo.inventoryItemInfo[counter] = inventory[counter].Itemtypes;
        inventoryInfo.inventoryItemName[counter] = inventory[counter].ItemName;
        inventoryInfo.inventroyItemEndurance[counter] = inventory[counter].Endurance;
        inventoryInfo.inventroyItemMastery[counter] = inventory[counter].Mastery;
        inventoryInfo.inventroyItemStrength[counter] = inventory[counter].Strength;
        inventoryInfo.inventoryItemIntellect[counter] = inventory[counter].Intellect;
        inventoryInfo.inventroyItemStamina[counter] = inventory[counter].Stamina;
        inventoryInfo.inventoryItemAgility[counter] = inventory[counter].Agility;




    }
    void initializeStructs(InventoryInfo inventoryinfo)
    {
        inventoryInfo.inventoryIdInfo = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //inventoryInfo.inventoryItemInfo = 
        inventoryInfo.inventoryItemName = new string[10] { "", " ", " ", " ", " ", " ", " ", " ", " ", " " };
        inventoryInfo.inventoryDesInfo = new string[10] { "", " ", " ", " ", " ", " ", " ", " ", " ", " " };
        inventoryInfo.inventoryItemAgility = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        inventoryInfo.inventroyItemStamina = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        inventoryInfo.inventroyItemEndurance = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        inventoryInfo.inventroyItemMastery = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        inventoryInfo.inventoryItemIntellect = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        inventoryInfo.inventroyItemStrength = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


    }
    void StructToList(int i)
    {
        i =p;
        inventory[i].ItemDescription = inventoryInfo.inventoryDesInfo[i];
        inventory[i].ItemID = inventoryInfo.inventoryIdInfo[i];
        inventory[i].ItemName = inventoryInfo.inventoryItemName[i];
        inventory[i].Endurance = inventoryInfo.inventroyItemEndurance[i];
        inventory[i].Mastery = inventoryInfo.inventroyItemMastery[i];
        inventory[i].Strength = inventoryInfo.inventroyItemStrength[i];
        inventory[i].Intellect = inventoryInfo.inventoryItemIntellect[i];
        inventory[i].Stamina = inventoryInfo.inventroyItemStamina[i];
        inventory[i].Agility = inventoryInfo.inventoryItemAgility[i];
        
        p++;
       
        

    }
    void initializeList()
    {
        inventory = new List<BaseItem>();
        for (int i = 0; i < 10; i++)
        {
          
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
     public List<BaseItem> ReturnPlayerInventory()
   {
       
        StructToList(p);
       return inventory;
    }
}
