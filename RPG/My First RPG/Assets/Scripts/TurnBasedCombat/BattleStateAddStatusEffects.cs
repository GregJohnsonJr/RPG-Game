using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateAddStatusEffects  {

public void CheckAbiliteisForStatusEffects(BaseAbility usedAbility)
    {
       
        switch(usedAbility.AbilityStatusEffect.StatusEffectName)
        {
            case("Burn"):
                if (TryToApplyStatusEffect(usedAbility))
                {
                    Debug.Log("RETURN TRUE, APPLIED EFFECT");
                    TurnBasedCombatStateMachine.statusEffectBaseDamage = (int)usedAbility.AbilityStatusEffect.StatusEffectPower;
                    Debug.Log(TurnBasedCombatStateMachine.statusEffectBaseDamage);
                }
                else
                {
                    TurnBasedCombatStateMachine.statusEffectBaseDamage = 0;
                }

                Debug.Log("Try To Apply Effect. Ability Has: " + usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage + "% Chance");
                TurnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.CALULATEDAMAGE;
                break;
           default:
                Debug.LogError("ERROR IN STATUS EFFECT");
                break;
           
        }
    
  
    }
    private bool TryToApplyStatusEffect(BaseAbility usedAbility)
    {
        // Look at the percent chance of stratus effect applying
        // using percent chance apply effect
        int randomTemp = Random.Range(1, 101); // random number between 1 and 100;
        Debug.Log(randomTemp);
        if (randomTemp <= usedAbility.AbilityStatusEffect.StatusEffectApplyPercentage) // apply the effect
        {

            return true;
        }
        return false;
    }
}
