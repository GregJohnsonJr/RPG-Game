using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedCombatStateMachine : MonoBehaviour {
    private bool hasAddedXp = false;
    private BattleStateStart battleStateStartScript = new BattleStateStart();
    private BattleCalulations battleCalcScript = new BattleCalulations();
    private BattleStateAddStatusEffects battleStateAddStatusEffectScript = new BattleStateAddStatusEffects();
    private BattleStateEnemyChoice battlestateEnemyChoiceScript = new BattleStateEnemyChoice();
    public static BaseAbility playerUsedAbility;
    public static BaseAbility enemyUsedAbility;
    public static int statusEffectBaseDamage;
    public static int totalTurnCount;
    public static bool playerDidCompleteTurn, enemyDidCompleteTurn;
    public static BattleStates currentUser; // enemy or player choice

    public enum BattleStates
    {
            START,
            PLAYERCHOICE,//Add Animation States Later
            ENEMYCHOICE,
            CALULATEDAMAGE,
            ADDSTATUSEFFECT,
            ENDTURN,
            LOST,
            WIN
    }


    public static BattleStates currentState;

	// Use this for initialization
	void Start () {
        currentState = BattleStates.START;
        hasAddedXp = false;
        totalTurnCount = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(currentState);
        switch (currentState)
        {

            // choose who goes first based on agility 
            case (BattleStates.START):
                //SetUP the battle functions maybe?
                battleStateStartScript.PrepareBattle();


                break;
            case (BattleStates.PLAYERCHOICE):
                currentUser = BattleStates.PLAYERCHOICE;
                break;
            case (BattleStates.ENEMYCHOICE): // AI scripting
                currentUser = BattleStates.ENEMYCHOICE;
                //coded ai 
                //enemyDidCompleteTurn = true;
                // CheckWhoGoesNext();
                battlestateEnemyChoiceScript.EnemyCompeleteTurn();               
                break;
            case (BattleStates.CALULATEDAMAGE):// calculate the damage
                if(currentUser == BattleStates.PLAYERCHOICE)
                {
                    battleCalcScript.CalculateTotalPlayerDamage(playerUsedAbility);
                }
                if (currentUser == BattleStates.ENEMYCHOICE)
                {
                    battleCalcScript.CalculateTotalEnemyDamage(enemyUsedAbility); // Run battle script for enemy
                }
                CheckWhoGoesNext();
                break;
            case (BattleStates.ADDSTATUSEFFECT): // status effects aquired if any
                battleStateAddStatusEffectScript.CheckAbiliteisForStatusEffects(playerUsedAbility);
                break;
            case (BattleStates.ENDTURN):
                totalTurnCount += 1;
                playerDidCompleteTurn = false;
                enemyDidCompleteTurn = false;
               // Debug.Log(totalTurnCount);
                break;
            case (BattleStates.LOST):
                break;
            case (BattleStates.WIN):
                if (!hasAddedXp)
                {

                    IncreasedExperience.AddExperience();
                    hasAddedXp = true;
                }
                break;
        }
        
	}
    void OnGUI()
    {
        if (GUILayout.Button("NEXT STATE"))
        {
            if (currentState == BattleStates.START)
            {
                currentState = BattleStates.PLAYERCHOICE;
            }
            else if (currentState == BattleStates.PLAYERCHOICE)
            {
                currentState = BattleStates.ENEMYCHOICE;
            }
            else if (currentState == BattleStates.ENEMYCHOICE)
            {
                currentState = BattleStates.LOST;
            }
            else if (currentState == BattleStates.LOST)
            {
                currentState = BattleStates.WIN;
            }
            else if (currentState == BattleStates.WIN)
            {
                currentState = BattleStates.START;
            }
        }
    }


    private void CheckWhoGoesNext()
    {
        if (playerDidCompleteTurn && !(enemyDidCompleteTurn))
        {
            //enemyTurn
            currentState = BattleStates.ENEMYCHOICE;
        }
            
        if(!(playerDidCompleteTurn) && enemyDidCompleteTurn)
        {
            //PlayerTurn
            currentState = BattleStates.PLAYERCHOICE;
        }

        if (playerDidCompleteTurn && enemyDidCompleteTurn)
        {
            //EndTurn State
            currentState = BattleStates.ENDTURN;
        }



    }
}
