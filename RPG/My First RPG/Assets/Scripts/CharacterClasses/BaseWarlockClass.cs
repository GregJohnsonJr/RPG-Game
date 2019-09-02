using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarlockClass : BaseCharacterClass{

    public BaseWarlockClass()
    // is a mage so focuses on Intellect and Endurance
    {
        CharacterClassName = "Warlock";
        CharacterClassDescrip = "A mage who specializes in undead type powers, and can use his powers to drain enemy life forces";
        Stamina = 9;
        Strength = 9;
        Endurance = 17;
        Intellect = 16;
        Agility = 11;
        Mastery = 11;
        Resistance = 12;
        MainStat = BaseCharacterClass.MainStatsBonuses.ENDURANCE;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.INTELLECT;
        BonusStat = BaseCharacterClass.BonusStatBonuses.MASTERY;
    }
}
