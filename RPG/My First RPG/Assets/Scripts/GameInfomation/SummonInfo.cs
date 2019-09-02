using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonInfo  {
    public string SummonName { get; set; }
    public int SummonLevel { get; set; }
    public float CritChance { get; set; }
    public float CritDamage { get; set; }
    public float SummonHealth { get; set; }
    public float SummonMaxHealth { get; set; }
    public float SummonEnergy { get; set; }
    public float SummonMaxEnergy { get; set; }
    public int SummonShield { get; set; }
    public int BaseDamage { get; set; }
    public int HealAmount { get; set; }
    public int ChannelledDuration { get; set; }
    public void CalculateDamage(int damage)
    {
        BaseDamage = damage;
    }
    public void CalculateHealth()
    {
        float health;
        health = GameInformation.PlayerHealth / 4;
        SummonMaxHealth = health;
        SummonHealth = health;
    }
    public void HealingCalc(int heal)
    {
        HealAmount = heal;
    }
    public void CalculateEnergy()
    {
        float energy;
        energy = GameInformation.PlayerEnergy / 2;
        SummonMaxEnergy = energy;
        SummonEnergy = energy;
    }
     public void CalculateCrit()
     {
        CritChance = GameInformation.CritChance / 2;
     }
}
