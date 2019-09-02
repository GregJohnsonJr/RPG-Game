using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArcherClass : BaseCharacterClass
{
    public BaseArcherClass()
    {
        //Make all stats add up to 79 at lvl 1, go back to warrior and mage later.
        //Needs lots of speed and agility to space foes. Agility and stamina prioritize agility
        CharacterClassName = "Archer";
        CharacterClassDescrip = "A powerful hunter who can attack from a range and keep his enemys at bay with his speed";
        Stamina = 14;
        Strength = 9;
        Endurance = 10;
        Intellect = 8;
        Agility = 19;
        Resistance = 9;
        Mastery = 10;
        MainStat = BaseCharacterClass.MainStatsBonuses.AGILITY;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.STAMINA;
        BonusStat = BaseCharacterClass.BonusStatBonuses.MASTERY;
    }
}