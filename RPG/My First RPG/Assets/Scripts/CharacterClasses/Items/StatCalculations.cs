using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculations
{ 
    private float enemyStaminaModifer = 0.11f;
    private float enemyEnduranceModifer = 0.10f;
    private float enemyIntellectModifer = 0.10f;
    private float enemyStrengthModifer = 0.09f;
    private float enemyAgilityModifer = 0.08f;
    private float enemyMasteryModifer = 0.08f;
    private float Statmodifer;
    private float mainStatModifer = 0.15f;
    private float secondMainStatModifer = 0.14f;
    public enum StatType
    {
        STAMINA,
        ENDURANCE,
        INTELLECT,
        STRENGTH,
        AGILITY,
        MASTERY
    }
    
    public int CalulateStat(int statVal, StatType statType, int level, bool isEnemy)
    {
        if (isEnemy)
        {
            SetEnemyModifer(statType);

            return (statVal + (int)((statVal * Statmodifer) * level));
        }else if (!isEnemy)
        {
            SetEnemyModifer(statType);
            return (statVal + (int)((statVal * Statmodifer) * level));
        }
        return 0;
    }
    public void CalculateLevelUpStats()
    {
        GameInformation.PlayerClass.SetMainStat();
        GameInformation.PlayerClass.SetSecondaryStat();
        GameInformation.PlayerClass.SetBonusStat();
        GameInformation.PlayerClass.GetMainStat();
        GameInformation.PlayerClass.GetSecondaryStat();
        GameInformation.Intellect = (int)(Mathf.Ceil((GameInformation.Intellect * enemyIntellectModifer) + GameInformation.Intellect + 1));
        GameInformation.Stamina = (int)((Mathf.Ceil(GameInformation.Stamina * enemyStaminaModifer) + GameInformation.Stamina + 1));
        GameInformation.Strength = (int)(Mathf.Ceil((GameInformation.Strength * enemyStrengthModifer) + GameInformation.Strength + 1));
        GameInformation.Mastery = (int)((Mathf.Ceil(GameInformation.Mastery * enemyMasteryModifer) + GameInformation.Mastery + 1));
        GameInformation.Agility = (int)((Mathf.Ceil(GameInformation.Agility * enemyAgilityModifer) + GameInformation.Agility + 1));
        GameInformation.Endurance = (int)(Mathf.Ceil(GameInformation.Endurance * enemyEnduranceModifer) + GameInformation.Endurance + 1);
        GameInformation.MainStat = (int)(Mathf.Ceil(GameInformation.MainStat * mainStatModifer) + GameInformation.MainStat + 1);
        GameInformation.SecondStat = (int)(Mathf.Ceil(GameInformation.SecondStat * secondMainStatModifer) + GameInformation.SecondStat + 1);
        GameInformation.PlayerMaxHp = CalculateHealth(GameInformation.Endurance);
        GameInformation.PlayerMaxEnergy = CalculateEnergy(GameInformation.Intellect);
        GameInformation.PlayerHealth = GameInformation.PlayerMaxHp;
        GameInformation.PlayerEnergy = GameInformation.PlayerMaxEnergy;
    }
    private void SetEnemyModifer(StatType statType)
    {

       
        if (statType == StatType.STAMINA)
        {
            Statmodifer = enemyStaminaModifer;
          
        }
        if (statType == StatType.ENDURANCE)
        {
            Statmodifer = enemyEnduranceModifer;
           
        }
        if (statType == StatType.INTELLECT)
        {
            Statmodifer = enemyIntellectModifer;
           
        }
        if (statType == StatType.STRENGTH)
        {
            Statmodifer = enemyStrengthModifer;
           
        }
        if (statType == StatType.AGILITY)
        {
            Statmodifer = enemyAgilityModifer;
        }
        if (statType == StatType.MASTERY)
        {
                Statmodifer = enemyMasteryModifer;

        }
        
       
    }
    /// <summary>
    /// statvalue is endurace
    /// </summary>
    /// <param name="statValue"></param>
    /// <returns></returns>
    public int CalculateHealth(int statValue)
    {
        return statValue*40; // Some classes will have different heal and mana growth then others
    }

    /// <summary>
    /// stat value is intellect
    /// </summary>
    /// <param name="statValue"></param>
    /// <returns></returns>
    public int CalculateEnergy(int statValue)
    {
        return statValue * 20;
    }

    public float FindPlayerMainStatAndCalculateMainStatModifer()
    {
        if(GameInformation.PlayerClass.MainStat == BaseCharacterClass.MainStatsBonuses.INTELLECT && GameInformation.PlayerClass.SecondMainStat == BaseCharacterClass.SecondStatBonuses.STAMINA)
        { // 17 int
            float GrabModifer;
            GrabModifer = GameInformation.Intellect;
            Debug.Log(GameInformation.Intellect);
            return ((GrabModifer * mainStatModifer)+ (GameInformation.Stamina * secondMainStatModifer));
        }
        return 0;
    }
}
