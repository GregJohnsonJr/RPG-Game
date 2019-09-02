using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRougeClass : BaseCharacterClass 
{

    public BaseRougeClass()
    {
        //Make all stats add up to 79 at lvl 1, go back to warrior and mage later.
        //This classes focuses on high damage but weak defensives. So a lot of stamina and agility for swift movemtns and a quick kill.
        CharacterClassName = "Rouge";
        CharacterClassDescrip = "A deadly assassin who dueled wields 2 daggers and uses many assassination techniques to kill his foes";
        Stamina = 17;
        Strength = 11;
        Endurance = 10;
        Intellect = 8;
        Agility = 16;
        Resistance = 10;
        Mastery = 8;
        MainStat = BaseCharacterClass.MainStatsBonuses.STAMINA;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.AGILITY;
        BonusStat = BaseCharacterClass.BonusStatBonuses.STRENGTH;
    }
}
