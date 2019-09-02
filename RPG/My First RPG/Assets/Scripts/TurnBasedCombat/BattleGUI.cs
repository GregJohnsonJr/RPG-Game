using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour {

    private Text playerName;
    private Image playerHealthImage;
    private int playerLevel;
    private Text abilityOneName;

    // private string playerName;
    // private int playerLevel;
    private Text playerHealth;
  //  private int playerHealth;
    private int playerEnergy;

	// Use this for initialization
	void Start () {
        playerName = transform.Find("PlayerInfoContainer").Find("PlayerPotrait").Find("PlayerName").GetComponent<Text>();
        playerName.text = GameInformation.PlayerName;
        playerHealth = transform.Find("PlayerInfoContainer").Find("HPBar").Find("PlayerHealthValue").GetComponent<Text>();
        playerHealthImage = transform.Find("PlayerInfoContainer").Find("HPBar").GetComponent<Image>();
        
        playerLevel = GameInformation.PlayerLevel;
        //playerName = GameInformation.PlayerName;
        // playerLevel = GameInformation.PlayerLevel;
       // Debug.Log(GameInformation.playerMoveTwo.AbilityStatusEffect.StatusEffectName);
	}
	// Update is called once per frame
	void Update () {
		playerName.text = GameInformation.PlayerName;
        playerHealth.text = GameInformation.PlayerHealth.ToString();
        // playerHealthImage.fillAmount = GameInformation.PlayerHealth / 1; This is how u make a hp/mana bar for losing hp/mana;

    }

    void OnGUI()
    {
        if( TurnBasedCombatStateMachine.currentState == TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE)
        {
            DisplayPlayersChoice();
        }

    }
    public void AbilityOne() // if u have a list of abilities, u could create a game object(prefab) then you make it into a scrtoll rect for all the abilites(lots of loops)
    {
        //TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECT;
    }
    
    private void DisplayPlayersChoice()
    {
        //we need buttons for players moves
        // USE FOR LOOP TO DISPLAY SERVERAL ABILITIES creats a action type bar. LOL caps;
        /*( for (int i = 0; i < GameInformation.playerAbilities.Count; i++)
         {
             if (GUI.Button(new Rect(0, 0, 0, 0), GameInformation.playerAbilities[i].AbilityName))
             {

             }
         }*/

       // if (GUI.Button(new Rect(Screen.width - 250, Screen.height - 50, 100, 30), GameInformation.playerMoveOne.AbilityName))
        { // calculate the player damage to the enemy
           // TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveOne;
           // TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECT;

        }
      //  if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 50, 100, 30), GameInformation.playerMoveTwo.AbilityName))
        {// calculate the player damage to the enemy
           // TurnBasedCombatStateMachine.playerUsedAbility = GameInformation.playerMoveTwo;
           // TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ADDSTATUSEFFECT;

        }

        // we need to show enemy health and other enemy information(name, hp, mana, etc)
        // show player information
    }

    public void FindAbilityOneInfo()
    {
        abilityOneName = transform.Find("MeleeAbilityContainer").Find("A1").Find("Text").GetComponent<Text>();
       // abilityOneName.text = GameInformation.playerMoveTwo.AbilityName; // Change back to proper abilities soon
    }

}
