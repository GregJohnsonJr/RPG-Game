using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnhancerClass : BaseCharacterClass
{
    public static List<object> abilities;
    public BaseEnhancerClass()
    {
        //Make all stats add up to 79 at lvl 1, go back to warrior and mage later.
        //This classes focuses on triStat Main Agility, Intellect, and Mastery.
        //Futuristic Mode?!!!?!?!?! for awaking??
        CharacterClassName = "Enhancer";
        CharacterClassDescrip = "A tatical class that utilizes summoning androids, and uses plasma gun. Later in the game his past gets revealed and a new power is released";
        Stamina = 12;
        Strength = 8;
        Endurance = 10;
        Intellect = 14;
        Agility = 15;
        Resistance = 8;
        Mastery = 14;
        MainStat = BaseCharacterClass.MainStatsBonuses.INTELLECT;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.AGILITY;
        BonusStat = BaseCharacterClass.BonusStatBonuses.MASTERY;

    }
}
interface EnhancerClass //Just so you know what class it is from
{
    void AddAbilityToClass();  
}

