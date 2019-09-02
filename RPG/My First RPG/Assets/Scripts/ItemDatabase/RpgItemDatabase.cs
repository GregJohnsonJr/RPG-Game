using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class RpgItemDatabase : MonoBehaviour {

    public TextAsset itemInventory;
    public static List<BaseItem> InventoryItems = new List<BaseItem>();
    private List<Dictionary<string, string>> InventoryItemsDictonary = new List<Dictionary<string, string>>();
    private Dictionary<string, string> inventoryDictonary;

    void Awake()
    {
        ReadItemsFromDatabase();
        for (int i = 0; i < InventoryItemsDictonary.Count; i++)
        {
            InventoryItems.Add(new BaseItem(InventoryItemsDictonary[i]));
   
        }
    }
    // Xml learnign
    // Xml uses access for database and it compiles all of your weapons and item.
    public void ReadItemsFromDatabase()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(itemInventory.text);
        XmlNodeList itemList = xmlDocument.GetElementsByTagName("Item");

        foreach(XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            inventoryDictonary = new Dictionary<string, string>(); // ItemName: TestItem



            foreach(XmlNode content in itemContent)
            {
                switch(content.Name)
                {
                    case "ItemName":
                        inventoryDictonary.Add("ItemName", content.InnerText);
                        break;
                    case "ItemID":
                        inventoryDictonary.Add("ItemID", content.InnerText);
                        break;
                    case "ItemType":
                        inventoryDictonary.Add("ItemType", content.InnerText);
                        break;
                }
            }
            InventoryItemsDictonary.Add(inventoryDictonary);
        }
    }

}
