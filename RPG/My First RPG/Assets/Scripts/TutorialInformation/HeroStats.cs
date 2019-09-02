using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    StatCalculations calculations;
    BaseCharacterClass baseCharacter;
    BasePlayer basePlayer;
    int level = 30;
    private void Awake()
    {
        baseCharacter = new BaseCharacterClass();
        calculations = new StatCalculations();
        basePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        Initialized();
    }
    void Initialized()
    {

        BaseWarriorClass warrior = new BaseWarriorClass(); // Need to make a method that gets the stats from warrior,
        baseCharacter.classess = BaseCharacterClass.CharacterClasses.WARRIOR;
        GameInformation.PlayerClass = baseCharacter;
        GameInformation.PlayerName = "Anaku";// Will change later once we get the actual names of the heros in the story.
        GameInformation.PlayerLevel = 0;
        GameInformation.Agility = warrior.Agility;
        GameInformation.Strength = warrior.Strength;
        GameInformation.Intellect = warrior.Intellect;
        GameInformation.Mastery = warrior.Mastery;
        GameInformation.Stamina = warrior.Stamina;
        GameInformation.Resistance = 100;
        GameInformation.Endurance = warrior.Endurance;
        GameInformation.PlayerHealth = calculations.CalculateHealth(GameInformation.Endurance);
        GameInformation.PlayerEnergy = calculations.CalculateEnergy(GameInformation.Intellect);
        GameInformation.CurrentXp = 0;
        GameInformation.CritChance = 5 + (GameInformation.Agility * 0.2f);// Affected by agility and items
        GameInformation.CritDamage = 2 * ((GameInformation.Agility * 0.1f) / 100); // Affect by agility and some items
        GameInformation.Zodiac = new BaseTigerClass(); // The zodiac side and zodiac you are
        GameInformation.SummonsUp = 0;
        basePlayer.SetStats(false);
        basePlayer.StatPointsToAllocate = 0;
        basePlayer.PlayerClass = GameInformation.PlayerClass;
        // This will be how we calculate the p layers main stat.
        LevelUp levelUp = new LevelUp();
        for (int i = 0; i < level; i++)
        {
            levelUp.LevelUpCharacter();
        }
        Debug.Log(GameInformation.RequiredXP);
    }
    private void Update()
    {
        if (GameInformation.CurrentXp > GameInformation.RequiredXP)
        {
            LevelUp level = new LevelUp();
            level.LevelUpCharacter();
        }
    }
}
