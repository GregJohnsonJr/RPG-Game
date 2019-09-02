using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePriestClass : BaseCharacterClass {
    public BasePriestClass()
    {
        //Make all stats add up to 79 at lvl 1, go back to warrior and mage later.
        // focuses on healing so Mastery and intellect
        CharacterClassName = "Priest";
        CharacterClassDescrip = "A powerful holy wizard who focuses on healing magic, and support magic to aid his allies";
        Stamina = 9;
        Strength = 9;
        Endurance = 10;
        Intellect = 18;
        Agility = 10;
        Resistance = 10;
        Mastery = 14;
        MainStat = BaseCharacterClass.MainStatsBonuses.INTELLECT;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.MASTERY;
        BonusStat = BaseCharacterClass.BonusStatBonuses.AGILITY;
    }
}
