using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class BaseEquipment : BaseItem {

  
    void Start()
    {

      
        
    }
    
    public enum EquipmentTypes
    {
        HEAD,
        CHEST,
        SHOULDER,
        NECK,
        FEET,
        EARRING,
        RING,
        LEGS
    }
    private EquipmentTypes equipmentType;
    private int spellEffectID;

    public EquipmentTypes EquipmentType
    {
        get { return equipmentType; }
        set { equipmentType = value; }
    }

    public int SpellEffectID
    {
        get { return spellEffectID; }
        set { spellEffectID = value; }
    }

}
