using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityChoice  {

    private float totalPlayerHealth;
    private int playerHealthPercentage;
    private BaseAbility chosenAbility;



    public BaseAbility ChooseEnemyAbility()
    {

        totalPlayerHealth = GameInformation.PlayerHealth;
        playerHealthPercentage = (int)(totalPlayerHealth / 100)*100;
       if(playerHealthPercentage >= 75)
        {
            return chosenAbility = new SwordSlash();
        }
        else if(playerHealthPercentage < 75 && playerHealthPercentage >= 25)
        {
            return chosenAbility = new SwordSlash();
        }
        else if (playerHealthPercentage < 25)
        {
            return chosenAbility = new SwordSlash();
        }
        return chosenAbility;
    }

    private BaseAbility chooseAbilityAtSeventyFivePercent()
    {
        return chosenAbility = new SwordSlash();
    }

}
