using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePaladinClass : BaseCharacterClass {
    
    public BasePaladinClass()
    {
        //Make all stats add up to 79 at lvl 1, go back to warrior and mage later.
        // Tanky, low healish class. Lots of resistances and Endurance
        CharacterClassName = "Paladin";
        CharacterClassDescrip = "A holy knight who can support his allies from afar and use his holy shield to keep enemys dazed";
        Stamina = 10;
        Strength = 13;
        Endurance = 15;
        Intellect = 8;
        Agility = 10;
        Resistance = 16;
        Mastery = 8;

        MainStat = BaseCharacterClass.MainStatsBonuses.ENDURANCE;
        SecondMainStat = BaseCharacterClass.SecondStatBonuses.STRENGTH;
        BonusStat = BaseCharacterClass.BonusStatBonuses.AGILITY;
        //CharacterClass = CharacterClasses.PALADIN;
    }
}
