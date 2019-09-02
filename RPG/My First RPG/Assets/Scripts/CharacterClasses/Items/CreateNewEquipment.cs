using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Change Item Names and Descriptions soon
public class CreateNewEquipment : MonoBehaviour
{
    // remeber /// is actually for summary lol,
    // You might have to make static variables here in order to send them to the playerInventory script. I have been trying to avoid doing it the hard way but, we have no choice. Old system for now we will change it up later.
    public static BaseEquipment newEquipment;
    public static BasePlayer basePlayer;
    public static PlayerInventory playerInventory;
    public static int agility;
    private string[] itemNames = new string[4] { "Common", "Great", "Amazing", "Insane" };
    private string[] itemDes = new string[2] { "A New cool item", " A new not-coolish item" };
    void Awake()
    {
        Start();
    }
    // Use this for initialization
    public void Start()
    {
        CreateEquipment();               
    }
    public void CreateEquipment()
    {
        newEquipment = gameObject.AddComponent<BaseEquipment>();
        newEquipment.ItemDescription = itemDes[Random.Range(0, itemDes.Length)];
        newEquipment.ItemName = itemNames[Random.Range(0, 3)] + " Item";
        newEquipment.ItemID = Random.Range(1, 101);
        ChooseItemType();
        newEquipment.Stamina = Random.Range(1 * GameInformation.PlayerLevel, 11 * GameInformation.PlayerLevel);
        newEquipment.Endurance = Random.Range(1 * GameInformation.PlayerLevel, 11 * GameInformation.PlayerLevel);
        newEquipment.Intellect = Random.Range(1 * GameInformation.PlayerLevel, 11 * GameInformation.PlayerLevel);
        newEquipment.Strength = Random.Range(1 * GameInformation.PlayerLevel, 11 * GameInformation.PlayerLevel);
        newEquipment.Agility = Random.Range(1 * GameInformation.PlayerLevel, 11 * GameInformation.PlayerLevel);
        agility = newEquipment.Agility;
        newEquipment.Mastery = Random.Range(1 * GameInformation.PlayerLevel, 6 * GameInformation.PlayerLevel);
    }
    private void ChooseItemType()
    {
        int randomTemp = Random.Range(1, 9);
        if (randomTemp == 1)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
        }
        else if (randomTemp == 2)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.SHOULDER;
        }
        else if (randomTemp == 3)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
        }
        else if (randomTemp == 4)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
        }
        else if (randomTemp == 5)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
        }
        else if (randomTemp == 6)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.NECK;
        }
        else if (randomTemp == 7)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.EARRING;
        }
        else if (randomTemp == 8)
        {
            newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.RING;
        }
    }
}
