using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInfomation : MonoBehaviour {

    public static void LoadAllInformation()
    {
       
            GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
            GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
            GameInformation.Intellect = PlayerPrefs.GetInt("INTELLECT");
            GameInformation.Endurance = PlayerPrefs.GetInt("ENDURANCE");
            GameInformation.Strength = PlayerPrefs.GetInt("STRENGTH");
            GameInformation.Stamina = PlayerPrefs.GetInt("STAMINA");
            GameInformation.Agility = PlayerPrefs.GetInt("AGILITY");
            GameInformation.Resistance = PlayerPrefs.GetInt("RESISTANCE");
            GameInformation.Mastery = PlayerPrefs.GetInt("MASTERY");
            GameInformation.Gold = PlayerPrefs.GetInt("GOLD");


        if (PlayerPrefs.GetString("EQUIPMENTITEM1") != null)
        {
            GameInformation.EquipmentOne = (BaseEquipment)PPSerialization.Load("EQUIPMENTITEM1");
        }
    }
}

