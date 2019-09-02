using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCalulations {
    private StatCalculations statCalcScript = new StatCalculations();
    private BaseAbility playerUsedAbility;
    private int abilityPower;
    private int statusEffectDamage;
    private int totalUsedAbilityDamage;
    private float totalAbilityPowerDamage;
    private float totalPlayerDamage;
    private int totalCritStrikeDamage;
    private float damageVarianceModifer = .025f; // 2.5%

    public void CalculateTotalPlayerDamage(BaseAbility usedAbility)
    {
        playerUsedAbility = usedAbility;
        totalUsedAbilityDamage = (int)CalculateAbilityDamage(usedAbility);
        totalCritStrikeDamage = CalculateCriticalStrikeDamage();
        statusEffectDamage = (int)CalculateStatusEffectDamage();
        totalPlayerDamage = totalUsedAbilityDamage + totalCritStrikeDamage + statusEffectDamage;
        totalPlayerDamage += Random.Range(-(totalPlayerDamage * damageVarianceModifer), (totalPlayerDamage * damageVarianceModifer));
        TurnBasedCombatStateMachine.playerDidCompleteTurn = true;
        //rnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
    }

    public void CalculateTotalEnemyDamage(BaseAbility usedAbility)
    {
        playerUsedAbility = usedAbility;
        totalUsedAbilityDamage = (int)CalculateAbilityDamage(usedAbility);
        totalCritStrikeDamage = CalculateCriticalStrikeDamage();
        statusEffectDamage = (int)CalculateStatusEffectDamage();
        totalPlayerDamage = totalUsedAbilityDamage + totalCritStrikeDamage + statusEffectDamage;
        totalPlayerDamage += Random.Range(-(totalPlayerDamage * damageVarianceModifer), (totalPlayerDamage * damageVarianceModifer));
        TurnBasedCombatStateMachine.enemyDidCompleteTurn = true;
        //rnBasedCombatStateMachine.currentState = TurnBasedCombatStateMachine.BattleStates.ENEMYCHOICE;
    }

    private float CalculateAbilityDamage(BaseAbility usedAbility)
    {
        abilityPower = usedAbility.AbilityPower; // This retrieves power of move
        totalAbilityPowerDamage = abilityPower*statCalcScript.FindPlayerMainStatAndCalculateMainStatModifer(); // Find main stat and use it as a modifer for damage
        return totalAbilityPowerDamage;
    }
    private float CalculateStatusEffectDamage()
    {
        Debug.Log("SDmg: " + statusEffectDamage);
       return statusEffectDamage = TurnBasedCombatStateMachine.statusEffectBaseDamage * GameInformation.PlayerLevel;
        
    }

    private int CalculateCriticalStrikeDamage()
    {
       if( DecideIfAbilityCriticallyHit())
        {
            totalCritStrikeDamage = 0;
            return totalCritStrikeDamage = (int)(playerUsedAbility.AbilityCritModifer * totalAbilityPowerDamage);
        }



        return  totalCritStrikeDamage = 0;
    }

    private bool DecideIfAbilityCriticallyHit()
    {
      
        int randomTemp = Random.Range(1, 101);
        if (randomTemp <= playerUsedAbility.AbilityCritChance)         
        {
            Debug.Log("Crit!");
            return true; //CRITICAL HIT
        }
        else
            return false;  //CRITICAL failed

    }



}
