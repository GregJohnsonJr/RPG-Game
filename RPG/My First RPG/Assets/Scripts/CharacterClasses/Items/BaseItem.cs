using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to save items (see below)
[System.Serializable]
//(above)
public class BaseItem : MonoBehaviour {


   
    public static string itemName;
    public static string itemDescription;
    public static int itemID;
    public static int stamina, endurance, strength, intellect, agility, mastery;
    public BaseItem() { }

    public enum ItemTypes
    {
        EQIUPMENT,
        WEAPON,
        SCROLL,
        POTION,
        CHEST
    }

    private ItemTypes itemType;
  
    


    public BaseItem(Dictionary<string, string > itemsDictionary)
    {
        itemName = itemsDictionary["ItemName"];
        itemID = int.Parse(itemsDictionary["ItemID"]);
        itemType = (ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), itemsDictionary["itemType"].ToString()); // Learn
    }
    
    
    // can make a setter/getter arry...hmmm
    
    public  string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public  string ItemDescription
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }
    public  int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
    public ItemTypes Itemtypes
    {
        get { return itemType; }
        set { itemType = value; }
    }
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }
    public int Intellect
    {
        get { return intellect; }
        set { intellect = value; }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Mastery
    {
        get { return mastery; }
        set { mastery = value; }
    }

    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }
}
