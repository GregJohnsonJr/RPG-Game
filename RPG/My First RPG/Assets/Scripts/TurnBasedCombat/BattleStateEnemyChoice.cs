using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateEnemyChoice  {

    private EnemyAbilityChoice enemyAbilityChoiceScript = new EnemyAbilityChoice();

    public void  EnemyCompeleteTurn()
    {
        // choose ability
        TurnBasedCombatStateMachine.enemyUsedAbility = enemyAbilityChoiceScript.ChooseEnemyAbility();
        Debug.Log("EnemyChoice " + TurnBasedCombatStateMachine.enemyUsedAbility.AbilityName);
        //calculate damage
        TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALULATEDAMAGE;
        //end turn

    }
    
	
}
