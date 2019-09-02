using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class ItemDatabase : MonoBehaviour {
    private List<Item> dataBase = new List<Item>();
    private JsonData itemData;


    void Start()
    {      
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/itemWork.json"));
        ConstructItemDataBase();
        //Debug.Log(FetchItemByID(0).Description);
    }
    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < dataBase.Count; i++)
        {
            if(dataBase[i].ID == id)
            return dataBase[i];
        }
        return null;
       
    }
	
void ConstructItemDataBase()
    {

        for (int i = 0; i < itemData.Count; i++)
        {            
                dataBase.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],
                    (int)itemData[i]["stats"]["strength"], (int)itemData[i]["stats"]["intellect"], (int)itemData[i]["stats"]["stamina"], (int)itemData[i]["stats"]["endurance"],
                    (int)itemData[i]["stats"]["agility"], (int)itemData[i]["stats"]["mastery"], itemData[i]["description"].ToString(), (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"],
                    itemData[i]["slug"].ToString(), itemData[i]["WeaponType"].ToString(), itemData[i]["Type"].ToString()));           
        }


    }



}
public class Item
{
    
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Strength { get; set; }
    public int Stamina { get; set; }
    public int Endurance { get; set; }
    public int Intellect { get; set; }
    public int Agility { get; set; }
    public int Mastery { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public bool Stackable { get; set; }
    public string WeaponType { get; set; }
    public string Type { get; set; }
    public int Rarity { get; set; }
    public Sprite Sprite { get; set; }
  
    public Item(int id, string title, int value, int strength, int intellect, int stamina, int endurance,  int agility, int mastery, string description, bool stackable, int rarity, string slug,string weaponType, string type )
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Strength = strength;
        this.Endurance = endurance;
        this.Intellect = intellect;
        this.Stamina = stamina;
        this.Agility = agility;
        this.Mastery = mastery;
        this.Description = description;
        this.Slug = slug;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Sprite = Resources.Load<Sprite>("Sprites/"+ slug);
        this.WeaponType = weaponType;
        this.Type = type;

    }

    public Item()
    {
        this.ID = -1;
    }


}