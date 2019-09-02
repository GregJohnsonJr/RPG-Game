using System.Collections.Generic;
[System.Serializable]
public class BaseAbility  {
    private string abilityName;
    private string abilityDescription;
    private int abilityID;
    private int abilityPower;
    private int abilityCost;
    private BaseStatusEffect abilityStatusEffect; // allows each ability to have one status effect
    private List<BaseStatusEffect> abilityStatusEffects = new List<BaseStatusEffect>(); // allow abilites to have multiple status effects;
    private int abilityCritChance;
    private float abilityCritModifer;
    //Add cool downs, status effects, and other effects later
    // BUILD A DATABASE SOON, VERY SOON WE HAVE TO LEARN HOW TO DO ALL THIS. DATABASE IS SO MUCH EASIER
    public string AbilityName
    {
        get { return abilityName; }
        set { abilityName = value; }
    }
    public string AbilityDescription
    {
        get { return abilityDescription; }
        set { abilityDescription = value; }
    }
    public int AbilityID
    {
        get { return abilityID; }
        set { abilityID = value; }
    }
    public int AbilityPower
    {
        get { return abilityPower; }
        set { abilityPower = value; }
    }
    public int AbilityCost
    {
        get { return abilityCost; }
        set { abilityCost = value; }
    }
    public List<BaseStatusEffect> AbilityStatusEffects
    {
        get { return abilityStatusEffects; }
        set { abilityStatusEffects = value; }
            


    }
    public BaseStatusEffect AbilityStatusEffect
    {
        get { return abilityStatusEffect; }
        set { abilityStatusEffect = value; }

    }
    public int AbilityCritChance
    {
        get { return abilityCritChance; }
        set { abilityCritChance = value; }
    }
    public float AbilityCritModifer
    {
        get { return abilityCritModifer; }
        set { abilityCritModifer = value; }
    }

}
