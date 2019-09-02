using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour {
    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        BaseEnemyScript baseEnemy = new BaseEnemyScript();
        //baseEnemy.CalculateEnemyInfo(2, 2, this, this.gameObject);
        //Debug.Log(PlayerHealth);
    }

   //public static string PlayerBio { get; set; }
    public bool IsMale { get; set; }
    public BaseEquipment EquipmentOne { get; set; }
    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public BaseCharacterClass PlayerClass { get; set; }
    public int Stamina { get; set; }
    public int Intellect { get; set; }
    public int Endurance { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Resistance { get; set; }
    public int Mastery { get; set; }
    public int Gold { get; set; }
    public int CurrentXp { get; set; }
    public int RequiredXP { get; set; }
    public int MainStat { get; set; }
    public int SecondStat { get; set; }
    public int BounsStat { get; set; }

    public int PlayerHealth { get; set; }
    public int PlayerMaxHealth { get; set; }
    public int PlayerEnergy { get; set; }
    public int PlayerMaxEnergy { get; set; }
}
