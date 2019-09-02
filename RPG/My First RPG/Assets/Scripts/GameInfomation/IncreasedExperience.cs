using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IncreasedExperience  {

    private static int xpGive;
    private static LevelUp levelUpScript = new LevelUp();

    public static void AddExperience()
    {
        xpGive = GameInformation.PlayerLevel * 100; //Make it more of a multiplier more later
        GameInformation.CurrentXp += xpGive;
        CheckToSeeIfPlayerLeveled();
        Debug.Log(xpGive);
    }

    //xp From lose also

     public static void AddLoseExperience()
    {
        xpGive = GameInformation.PlayerLevel * 15;
        GameInformation.CurrentXp += xpGive;
        CheckToSeeIfPlayerLeveled();
        Debug.Log(xpGive);
    }
    public static void AddExplorationExperience()
    {
       // xpToGive = GameInformation.Playerlevel *10
    }

    private static void CheckToSeeIfPlayerLeveled()
    {
        if  (GameInformation.CurrentXp >= GameInformation.RequiredXP)
        {
            //LVL UP
            levelUpScript.LevelUpCharacter();
            
            //Create a lvl up script
        }
    }

   
}
