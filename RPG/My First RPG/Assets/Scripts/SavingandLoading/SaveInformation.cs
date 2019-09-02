using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation  {

	public static void SaveAllInformation()
    {
        PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
        PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
        PlayerPrefs.SetInt("INTELLECT", GameInformation.Intellect);
        PlayerPrefs.SetInt("ENDURANCE", GameInformation.Endurance);
        PlayerPrefs.SetInt("STRENGTH", GameInformation.Strength);
        PlayerPrefs.SetInt("STAMINA", GameInformation.Stamina);
        PlayerPrefs.SetInt("AGILITY", GameInformation.Agility);
        PlayerPrefs.SetInt("RESISTANCE", GameInformation.Resistance);
        PlayerPrefs.SetInt("MASTERY", GameInformation.Mastery);
        PlayerPrefs.SetInt("GOLD", GameInformation.Gold);

        if (GameInformation.EquipmentOne != null)
        PPSerialization.Save("EQUIPMENTITEM1", GameInformation.EquipmentOne);
        Debug.Log("Saved All Information");
    }
}
