using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass : MonoBehaviour
{

    public string characterClassName;
    public string characterClassDescrip;

    //stats
    public int stamina;
    public int intellect;
    public int endurance;
    public int strength;
    public int agility, resistance, mastery;
    public CharacterClasses classess;



    public enum CharacterClasses
    {
     WARRIOR,
     MAGE,
     ARCHER,
     ROUGE,
     WARLOCK,
     PALADIN,
     PRIEST,
     Enhancer
    }

    public enum MainStatsBonuses
    {
        STAMINA,
        ENDURANCE,
        STRENGTH,
        INTELLECT,
        AGILITY
    }
    
    public enum SecondStatBonuses
    {
        STAMINA,
        ENDURANCE,
        STRENGTH,
        INTELLECT,
        AGILITY,
        MASTERY
    }

    public enum BonusStatBonuses
    {
        STAMINA,
        ENDURANCE,
        STRENGTH,
        INTELLECT,
        AGILITY,
        MASTERY
    }
   
    public List<BaseAbility> playersAbilities = new List<BaseAbility>();
    
    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }

    public string CharacterClassDescrip
    {
        get { return characterClassDescrip; }
        set { characterClassDescrip = value; }
    }

    public MainStatsBonuses MainStat { get; set; }
    public SecondStatBonuses SecondMainStat { get; set; }
    public BonusStatBonuses BonusStat { get; set; }
    
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
    public void GetMainStat()
    {
        if(MainStat == MainStatsBonuses.AGILITY)
        {
            GameInformation.Agility =  Agility;
            GameInformation.MainStat = Agility;
        }
        if (MainStat == MainStatsBonuses.INTELLECT)
        {
            GameInformation.Intellect = Intellect;
            GameInformation.MainStat = Intellect;
        }
        if (MainStat == MainStatsBonuses.STAMINA)
        {
            GameInformation.Stamina = Stamina;
            GameInformation.MainStat = Stamina;
        }
        if (MainStat == MainStatsBonuses.ENDURANCE)
        {
            GameInformation.Endurance = Endurance;
            GameInformation.MainStat = Endurance;
        }
        if (MainStat == MainStatsBonuses.STRENGTH)
        {
            GameInformation.Strength = Strength;
            GameInformation.MainStat = Strength;
        }
       
    }
    public void GetSecondaryStat()
    {

        if (SecondMainStat == SecondStatBonuses.AGILITY)
        {
            GameInformation.Agility = Agility;
            GameInformation.SecondStat = Agility;
        }
        if (SecondMainStat == SecondStatBonuses.INTELLECT)
        {
            GameInformation.Intellect = Intellect;
            GameInformation.SecondStat = Intellect;
        }
        if (SecondMainStat == SecondStatBonuses.STAMINA)
        {
            GameInformation.Stamina = Stamina;
            GameInformation.SecondStat = Stamina;
        }
        if (SecondMainStat == SecondStatBonuses.ENDURANCE)
        {
            GameInformation.Endurance = Endurance;
            GameInformation.SecondStat = Endurance;
        }
        if (SecondMainStat == SecondStatBonuses.STRENGTH)
        {
            GameInformation.Strength = Strength;
            GameInformation.SecondStat = Strength;
        }
        if (SecondMainStat == SecondStatBonuses.MASTERY)
        {
            GameInformation.Mastery = Mastery;
            GameInformation.SecondStat = Mastery;
        }
    }
    public void GetBonusStat()
    {

        if (BonusStat == BonusStatBonuses.AGILITY)
        {
            GameInformation.Agility = Agility;
            GameInformation.BounsStat = Agility;
        }
        if (BonusStat == BonusStatBonuses.INTELLECT)
        {
            GameInformation.Intellect = Intellect;
            GameInformation.BounsStat = Intellect;
        }
        if (BonusStat == BonusStatBonuses.STAMINA)
        {
            GameInformation.Stamina = Stamina;
            GameInformation.BounsStat = Stamina;
        }
        if (BonusStat == BonusStatBonuses.ENDURANCE)
        {
            GameInformation.Endurance = Endurance;
            GameInformation.BounsStat = Endurance;
        }
        if (BonusStat == BonusStatBonuses.STRENGTH)
        {
            GameInformation.Strength = Strength;
            GameInformation.BounsStat = Strength;
        }
        if (BonusStat == BonusStatBonuses.MASTERY)
        {
            GameInformation.Mastery = Mastery;
             GameInformation.BounsStat = Mastery;
        }
    }
    public void SetMainStat()
    {
        if (MainStat == MainStatsBonuses.AGILITY)
        {
            Agility = GameInformation.Agility;
        }
        if (MainStat == MainStatsBonuses.INTELLECT)
        {
            Intellect = GameInformation.Intellect;
        }
        if (MainStat == MainStatsBonuses.STAMINA)
        {
           Stamina =  GameInformation.Stamina;
        }
        if (MainStat == MainStatsBonuses.ENDURANCE)
        {
            Endurance = GameInformation.Endurance;
        }
        if (MainStat == MainStatsBonuses.STRENGTH)
        {
            Strength = GameInformation.Strength;
        }

    }
    public void SetSecondaryStat()
    {

        if (SecondMainStat == SecondStatBonuses.AGILITY)
        {
            Agility = GameInformation.Agility;
        }
        if (SecondMainStat == SecondStatBonuses.INTELLECT)
        {
            Intellect = GameInformation.Intellect;
        }
        if (SecondMainStat == SecondStatBonuses.STAMINA)
        {
            Stamina = GameInformation.Stamina;
        }
        if (SecondMainStat == SecondStatBonuses.ENDURANCE)
        {
            Endurance = GameInformation.Endurance;
        }
        if (SecondMainStat == SecondStatBonuses.STRENGTH)
        {
            Strength = GameInformation.Strength;
        }
        if (SecondMainStat == SecondStatBonuses.MASTERY)
        {
            Mastery = GameInformation.Mastery;
        }
    }
    public void SetBonusStat()
    {
        if (BonusStat == BonusStatBonuses.AGILITY)
        {
            Agility = GameInformation.Agility;
        }
        if (BonusStat == BonusStatBonuses.INTELLECT)
        {
            Intellect = GameInformation.Intellect;
        }
        if (BonusStat == BonusStatBonuses.STAMINA)
        {
            Stamina = GameInformation.Stamina;
        }
        if (BonusStat == BonusStatBonuses.ENDURANCE)
        {
            Endurance = GameInformation.Endurance;
        }
        if (BonusStat == BonusStatBonuses.STRENGTH)
        {
            Strength = GameInformation.Strength;
        }
        if (BonusStat == BonusStatBonuses.MASTERY)
        {
            Mastery = GameInformation.Mastery;
        }
    }
}
