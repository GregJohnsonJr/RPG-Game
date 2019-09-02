using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just add a instance of level up in your code to check for this.
public class LevelUp{

    public int maxPlayerLevel = 50;


    //Increase level by adding one
    public void LevelUpCharacter()
    {
        //Check to see if current xp > than required xp
        if(GameInformation.CurrentXp> GameInformation.RequiredXP)
        {
            GameInformation.CurrentXp -= GameInformation.RequiredXP;
        }
        else
        {
            GameInformation.CurrentXp = 0;

        }
        if (GameInformation.PlayerLevel < maxPlayerLevel)
        {
            GameInformation.PlayerLevel += 1;
            //Debug.Log(GameInformation.PlayerLevel);
        }
        else
        {
            GameInformation.PlayerLevel = maxPlayerLevel;
        }


        //give player stat points
        //Give them skill points for moves
        //reset xp
        //Next amount of required xp
        DetermineRequiredXP();
        CalculateNewStats();
        BasePlayer basePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        basePlayer.SetStats(true);
    }

    private void DetermineRequiredXP()
    {
        //Change algroithm
        int temp = (GameInformation.PlayerLevel * 30) + 250;
        GameInformation.RequiredXP += temp;
        if(GameInformation.CurrentXp > GameInformation.RequiredXP)
        {
            LevelUpCharacter();
        }

    }
    void CalculateNewStats()
    {
        StatCalculations stat = new StatCalculations();
        stat.CalculateLevelUpStats();
    }

}
	


