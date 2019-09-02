using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatusEffect
{

    public string statusEffectName;
    public string statusEffectDescription;
    public int statusEffectID;
    public float statusEffectPower;
    public int statusEffectApplyPercentage;
    public int statusEffectMinTurnApplied;
    public int statusEffectMaxTurnApplied;
    public int statusEffectStayAppliedPercentage;
    public int duration;
    //Add cool downs, status effects, and other effects later
    // BUILD A DATABASE SOON, VERY SOON WE HAVE TO LEARN HOW TO DO ALL THIS. DATABASE IS SO MUCH EASIER
    public string StatusEffectName
    {
        get { return statusEffectName; }
        set { statusEffectName = value; }
    }
    public string StatusEffectDescription
    {
        get { return statusEffectDescription; }
        set { statusEffectDescription = value; }
    }
    public int StatusEffectID
    {
        get { return statusEffectID; }
        set { statusEffectID = value; }
    }
    /// <summary>
    /// Remember to cast the Status effect power with a (int) since it is a float
    /// </summary>
    public float StatusEffectPower
    {
        get { return statusEffectPower; }
        set { statusEffectPower = value; }
    }
    public int StatusEffectApplyPercentage
    {
        get { return statusEffectApplyPercentage; }
        set { statusEffectApplyPercentage = value; }
    }
    public int StatusEffectMinTurnApplied
    {
        get { return statusEffectMinTurnApplied; }
        set { statusEffectMinTurnApplied = value; }
    }
    public int StatusEffectMaxTurnApplied
    {
        get { return statusEffectMaxTurnApplied; }
        set { statusEffectMaxTurnApplied = value; }
    }
    public int StatusEffectStayAppliedPercentage
    {
        get { return statusEffectStayAppliedPercentage; }
        set { statusEffectStayAppliedPercentage = value; }
    }
    public int Duration
    {
        get { return duration; }
        set { duration = value; }
    }
    public bool CheckifStatusEffectWorked(int chance)
    {
        int random = Random.Range(0, 100);
        if (random <= chance)
        {
            return true;
        }
        return false;
    }
}
