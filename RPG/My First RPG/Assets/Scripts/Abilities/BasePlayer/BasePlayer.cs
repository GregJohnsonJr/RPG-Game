using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour{

    public string playerName;
    public int playerLevel;
    public BaseCharacterClass playerClass;

    public int stamina;    //For sprinting and using certian moves
    public int endurance;  //Health
    public int intellect;  //Magic Damage Boost
    public int strength;   //Base Attack Increase for base attack as well as a damage modifier for certain moves
    public int agility;    //Speed Increase(Determines how fast you move and increases damage for certain moves,crit modifier, basically dexterity)
    public int resistance; //Increses Damage reductions 
    public int mastery;    //Increase Damage of certain moves and increases special move damage

    public int gold; //InGame Currency
    private int currentXP;
    private int requiredXP;
    private int statPointsToAllocate;
    // -> i could lowkey use this if i wanted to randomize stats for equipment
    public CreateNewEquipment newEquipment = new CreateNewEquipment();
   
    
    public float CurrentXP { get; set; }
    public float RequiredXP { get; set; }
    public int StatPointsToAllocate { get; set; }
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    //public string PlayerName { get; set; } other way
    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }
    public BaseCharacterClass PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }
    }
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }
    public int Intellect
    {
        get { return intellect; }
        set { intellect = value; }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }
    public int Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }
    public int Mastery
    {
        get { return mastery; }
        set { mastery = value; }
    }
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }
    public void SetStats(bool leveledUP)
    {
        Intellect = GameInformation.Intellect;
        Strength = GameInformation.Strength;
        Stamina = GameInformation.Stamina;
        Endurance = GameInformation.Endurance;
        Agility = GameInformation.Agility;
        Mastery = GameInformation.Mastery;
        Resistance = GameInformation.Resistance;
        CurrentXP = GameInformation.CurrentXp;
        RequiredXP = GameInformation.RequiredXP;
        if(leveledUP)
        { 
            StatPointsToAllocate += 5;
            //Debug.Log(StatPointsToAllocate); // <- going to have something for this you will see...
        }

    }
    public void SetBuffDuration(int time, string type, int amount)
    {
        StartCoroutine(Duration(time, type, amount));
    }
    IEnumerator Duration(int time, string type, int amount)
    {
        yield return new WaitForSeconds(time);
        if (type == "Strength")
        {
            GameInformation.Strength -= amount;
            GameInformation.BuffedStrength -= amount;
        }
        else if (type == "Stamina")
        {
            GameInformation.Stamina -= amount;
            GameInformation.BuffedStamina -= amount;
        }
        else if (type == "Endurance")
        {
            GameInformation.Endurance -= amount;
            GameInformation.BuffedEndurance -= amount;
        }
        else if (type == "Agility")
        {
            GameInformation.Agility -= amount;
            GameInformation.BuffedAgility -= amount;
        }
        else if (type == "Mastery")
        {
            GameInformation.Mastery -= amount;
            GameInformation.BuffedMastery -= amount;
        }
        else if (type == "Resistance")
        {
            GameInformation.Resistance -= amount;
            GameInformation.BuffedResistance -= amount;
        }
        else if (type == "Intellect")
        {
            GameInformation.Intellect -= amount;
            GameInformation.BuffedIntellect -= amount;
        }
        else if (type == "Shield")
        {
            // Have to make sure things do not go negative
            GameInformation.PlayerShield -= amount;
            if(GameInformation.PlayerShield < 0)
            {
                GameInformation.PlayerShield = 0;
            }
        }
        else if (type == "Health")
        {
            GameInformation.PlayerHealth -= amount;
            GameInformation.BuffedPlayerHealth -= amount;
        }
        else if (type == "Energy")
        {
            GameInformation.PlayerEnergy -= amount;
            GameInformation.BuffedPlayerEnergy -= amount;
        }
    }
    // Equipment Layout might have to make a new base player script, will see
}
