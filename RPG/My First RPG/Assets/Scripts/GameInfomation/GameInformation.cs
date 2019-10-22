using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        activeQuest = new List<FetchQuest>();

    }
    void InitializeClassSetup()
    {
        Intellect += PlayerClass.Intellect;
        Strength += PlayerClass.Strength;
        Stamina += PlayerClass.Stamina;
        Agility += PlayerClass.Agility;
        Endurance += PlayerClass.Endurance;
        Mastery += PlayerClass.Mastery;
        Resistance += PlayerClass.Resistance;
    }
    // public static List<BaseAbility> playerAbilities; //another way

    public static string PlayerBio { get; set; }
    public static bool IsMale { get; set; }
    public static BaseEquipment EquipmentOne { get; set; }
    public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static BaseCharacterClass PlayerClass { get; set; }
    public static BaseCharacterRace Race { get; set; }
    public static int Stamina { get; set; }
    public static int Intellect { get; set; }
    public static int Endurance { get; set; }
    public static int Strength { get; set; }
    public static int Agility { get; set; }
    public static int Resistance { get; set; }
    public static int Mastery { get; set; }
    public static int BuffedStamina {get;set;}
    public static int BuffedIntellect { get; set; }
    public static int BuffedStrength { get; set; }
    public static int BuffedAgility { get; set; }
    public static int BuffedResistance { get; set; }
    public static int BuffedMastery { get; set; }
    public static int BuffedEndurance { get; set; }
    public static int BuffedPlayerHealth { get; set; }
    public static int BuffedPlayerEnergy { get; set; }
    public static int Gold { get; set; }
    public static float CurrentXp { get; set; }
    public static float RequiredXP { get; set; }
    public static int MainStat { get; set; }
    public static int SecondStat { get; set; }
    public static int BounsStat { get; set; }
    public static float CritChance { get; set; }
    public static float CritDamage { get; set; }
    public static ZodiacClass Zodiac{ get; set; }
    public static float PlayerHealth { get; set; }
    public static float PlayerMaxHp { get; set; }
    public static float PlayerEnergy { get; set; }
    public static float PlayerMaxEnergy { get; set; }
    public static int PlayerShield { get; set; }
    //public static BaseAbility playerMoveOne = new AttackAbility();
    //public static BaseAbility playerMoveTwo = new SwordSlash();
    public static List<FetchQuest> activeQuest;
    public static int SummonsUp { get; set; } // Max of 2
    
}
