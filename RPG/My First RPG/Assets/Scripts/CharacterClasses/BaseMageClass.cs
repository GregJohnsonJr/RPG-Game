using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMageClass : BaseCharacterClass
{

    // is a mage so focuses on Intellect and mastery   
    public BaseMageClass()
    {
        CharacterClassName = "Mage";
        Stamina = 9;
        CharacterClassDescrip = "A Power mage who using magic to destroy his foes and aid his allies";
        Strength = 9;
        Endurance = 11;
        Intellect = 15;
        Agility = 11;
        Mastery = 17;
        Resistance = 10;
        MainStat = BaseCharacterClass.MainStatsBonuses.INTELLECT;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.MASTERY;
        BonusStat = BaseCharacterClass.BonusStatBonuses.AGILITY;
    }

}
