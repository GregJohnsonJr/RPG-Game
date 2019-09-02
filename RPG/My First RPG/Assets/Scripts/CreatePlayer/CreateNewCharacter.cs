using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Soon add a trailer added all the game play and such, but that will be once the game is finished
// This will probably be like a 1 and a half month project so be prepared <- Already Prepared we going crazy
// VR after <- Done!!!!!!!!!!
public class CreateNewCharacter : MonoBehaviour {

    private BasePlayer newPlayer;
    private bool isMageClass, isWarriorClass;
    private string playerName = "Enter Name";
	// Use this for initialization
	void Start () {
        newPlayer = new BasePlayer();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        // Add all the other classes soon
        playerName = GUILayout.TextArea(playerName,15);
        isMageClass = GUILayout.Toggle(isMageClass, "Mage Class");
        isWarriorClass = GUILayout.Toggle(isWarriorClass, "Warrior Class");
        if (GUILayout.Button("Create")){
            if (isMageClass)
                newPlayer.PlayerClass = new BaseMageClass();
            else if (isWarriorClass)
                newPlayer.PlayerClass = new BaseWarriorClass();
            CreateNewPlayer();
            StoreNewPlayerInfo();
            SaveInformation.SaveAllInformation();
           

        }

        if (GUILayout.Button("Load"))
        {
            SceneManager.LoadScene("Test");
        }
       
    }

    private void StoreNewPlayerInfo()
    {
        GameInformation.PlayerName = newPlayer.PlayerName;
        GameInformation.PlayerLevel = newPlayer.PlayerLevel;
        GameInformation.Stamina = newPlayer.Stamina;
        GameInformation.Intellect = newPlayer.Intellect;
        GameInformation.Endurance = newPlayer.Endurance;
        GameInformation.Strength = newPlayer.Strength;
        GameInformation.Agility = newPlayer.Agility;
        GameInformation.Resistance = newPlayer.Resistance;
        GameInformation.Mastery = newPlayer.Mastery;
        GameInformation.Gold = newPlayer.Gold;
    }

    private void CreateNewPlayer()
    {
        newPlayer.PlayerLevel = 1;
        newPlayer.Stamina = newPlayer.PlayerClass.Stamina;
        newPlayer.Intellect = newPlayer.PlayerClass.Intellect;
        newPlayer.Endurance = newPlayer.PlayerClass.Endurance;
        newPlayer.Strength = newPlayer.PlayerClass.Strength;
        newPlayer.Agility = newPlayer.PlayerClass.Agility;
        newPlayer.Resistance = newPlayer.PlayerClass.Resistance;
        newPlayer.Mastery = newPlayer.PlayerClass.Mastery;
        newPlayer.Gold = 10;
        newPlayer.PlayerName = playerName;
        Debug.Log("Player Name: " + newPlayer.PlayerName);
        Debug.Log("Player Class: " + newPlayer.PlayerClass.CharacterClassName);
        Debug.Log("Player Level: " + newPlayer.PlayerLevel);
        Debug.Log("Player Stamina: " + newPlayer.Stamina);
        Debug.Log("Player Endurance " + newPlayer.Endurance);
        Debug.Log("Player Intellect " + newPlayer.Intellect);
        Debug.Log("Player Strength: " + newPlayer.Strength);
        Debug.Log("Player Agility " + newPlayer.Agility);
        Debug.Log("Player Resistance: " + newPlayer.Resistance);
        Debug.Log("Player Mastery " + newPlayer.Mastery);
        Debug.Log("Player Gold: " + newPlayer.Gold);


    }

}
