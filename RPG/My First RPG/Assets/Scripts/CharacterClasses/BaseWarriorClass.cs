using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarriorClass : BaseCharacterClass
{

    public BaseWarriorClass()
    {
        //Focues on a tanky damage class
        CharacterClassName = "Warrior";
        CharacterClassDescrip = "A very strong hero who helps his allies while being in the front.";
        Stamina = 10;
        Strength = 13;
        Endurance = 13;
        Intellect = 9;
        Agility = 12;
        Resistance = 15;
        Mastery = 9;
        MainStat = BaseCharacterClass.MainStatsBonuses.ENDURANCE;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.STRENGTH;
        BonusStat = BaseCharacterClass.BonusStatBonuses.AGILITY;
        playersAbilities.Add(new AttackAbility());// how to add starting class abilites, ADDDD THEMMMM
        playersAbilities.Add(new SwordSlash());

    }
    public void GetMainStat()
    {

    }
}
