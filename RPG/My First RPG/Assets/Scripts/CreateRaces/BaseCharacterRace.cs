using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterRace {

    private string raceName = "Needs a Name!!!";
    private string raceDescription = "Needs a Description";
    public float percentIncrease = 0.2f;
   
    public string RaceName
    {
        get { return raceName; }
        set { raceName = value; }
        }
    public string RaceDescription
    {
        get { return raceDescription; }
        set { raceDescription = value; }
    }

    public bool HasStrengthBonus { set; get; } // Maybe like 2% so its not too much for each category
    public bool HasIntellectBonus { set; get; }
    public bool HasStaminaBonus { set; get; }
    public bool HasEnduranceBonus { set; get; }
    public bool HasAgilityBonus { set; get; }
    public bool HasMasteryBonus { set; get; }
    public bool HasHealingBonus { get; set; }
    
  

}
