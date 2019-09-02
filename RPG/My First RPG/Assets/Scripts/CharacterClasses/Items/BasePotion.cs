using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePotion : BaseItem {

	public enum PotionTypes
    {
        HEALTH,
        ENERGY,
        STRENGTH,
        INTELLECT,
        EVASION,
        EDURANCE,
        VITALITY,
        SPEED,
        MASTERY
    }
    private PotionTypes potionType;
    private int spellEffectID;

    public PotionTypes PotionType
    {
        get { return potionType; }
        set { potionType = value; }
    }

    public int SpellEffectID
    {
        get { return spellEffectID; }
        set { spellEffectID = value; }
    }
}
