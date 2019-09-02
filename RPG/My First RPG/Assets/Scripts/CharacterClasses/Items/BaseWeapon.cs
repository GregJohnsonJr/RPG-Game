using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : BaseItem {        //BaseWeapon <- BaseStat Item <- BaseItem
    
	public enum WeaponTypes
    {
        SWORD,
        STAFF,
        DAGGER,
        AX,
        BOW,
        SHIELD,
        POLEARM
    }
    private WeaponTypes weaponType;
    private int spellEffect;

    public WeaponTypes WeaponType
    {
        get { return weaponType; }
        set { weaponType = value; }
    }

    public int SpellEffectID
    {
        get { return spellEffect; }
        set { spellEffect = value; }
    }
}
