using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart  {

    public  BasePlayer newEnemy = new BasePlayer();
    private StatCalculations statCalculations = new StatCalculations();
    private BaseCharacterClass[] classTypes = new BaseCharacterClass[] { new BaseMageClass(), new BaseWarriorClass(), new BaseWarlockClass(), new BasePaladinClass(), new BasePriestClass(), new BaseArcherClass(), new BaseRougeClass(), new BaseEnhancerClass() };
    private int playerStamina;
    private int playerEndurance;
    private int playerHealth;
    private int playerEnergy;
    private string[] enemynames = new string[] { "Deadly Enemy", "Fierce Enemy", "Powerful Enemy", "Toxic Enemy" };
  
    public void PrepareBattle()
    {
        //create enemy( maybe randomized)
        CreateNewEnemy();
        //Find are stats
        DeterminePlayerVitatls();
        // who goes first???
        ChooseWhoGoesFirst();
        //choose who goes first based on agility(going to have hidden speed stat maybe)
        // Does the scene have a status effect??
        // if so set it up at the beginning of the fight

    }
    private void CreateNewEnemy()
    {
        newEnemy.PlayerName = enemynames[Random.Range(0,enemynames.Length)];
        newEnemy.PlayerLevel = Random.Range(GameInformation.PlayerLevel - 2, GameInformation.PlayerLevel + 2);
        newEnemy.PlayerClass = classTypes[Random.Range(0, classTypes.Length )]; // randomly choosing a class out of the array above
        newEnemy.Stamina = statCalculations.CalulateStat(newEnemy.Stamina, StatCalculations.StatType.STAMINA, newEnemy.PlayerLevel, true);
        newEnemy.Endurance = statCalculations.CalulateStat(newEnemy.Endurance, StatCalculations.StatType.ENDURANCE, newEnemy.PlayerLevel,true);
        newEnemy.Intellect = statCalculations.CalulateStat(newEnemy.Intellect, StatCalculations.StatType.INTELLECT, newEnemy.PlayerLevel, true);
        newEnemy.Strength = statCalculations.CalulateStat(newEnemy.Strength, StatCalculations.StatType.STRENGTH, newEnemy.PlayerLevel, true);
        newEnemy.Agility = statCalculations.CalulateStat(newEnemy.Agility, StatCalculations.StatType.AGILITY, newEnemy.PlayerLevel, true);
        newEnemy.Mastery = statCalculations.CalulateStat(newEnemy.Mastery, StatCalculations.StatType.MASTERY, newEnemy.PlayerLevel, true);
    }

    private void ChooseWhoGoesFirst()
    {

        if (GameInformation.Agility > newEnemy.Agility)
        {
            // player goes first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;
        }
        if (GameInformation.Agility < newEnemy.Agility)
        {
            //enemy goes if
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;

        }
        if (GameInformation.Agility == newEnemy.Agility)
        {
            //a tie lets let the player go first
            TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.PLAYERCHOICE;


        }


    }

    private void DeterminePlayerVitatls()
    {
        GameInformation.PlayerName = "Test Name";
        GameInformation.PlayerClass = new BaseMageClass(); // Change it instantly makes it a mage class, maybe switch cases/ if else?
        GameInformation.Intellect = GameInformation.PlayerClass.Intellect;
        GameInformation.Stamina = GameInformation.PlayerClass.Stamina;
        GameInformation.Endurance = GameInformation.PlayerClass.Endurance;
        playerStamina = statCalculations.CalulateStat(GameInformation.Stamina, StatCalculations.StatType.STAMINA, GameInformation.PlayerLevel, false);
        playerEndurance = statCalculations.CalulateStat(GameInformation.Endurance, StatCalculations.StatType.ENDURANCE, GameInformation.PlayerLevel, false);
        playerHealth = statCalculations.CalculateHealth(playerEndurance);
        playerEnergy = statCalculations.CalculateEnergy(playerStamina);
        GameInformation.PlayerLevel = 1;
        Debug.Log(GameInformation.PlayerHealth);
        GameInformation.PlayerHealth = playerHealth;
        GameInformation.PlayerEnergy = playerEnergy;

    }
}
