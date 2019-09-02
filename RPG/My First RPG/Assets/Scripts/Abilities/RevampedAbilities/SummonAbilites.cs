using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAbilites  {
    void CalculateSummonStats(SummonInfo info)
    {
        info.SummonHealth = GameInformation.PlayerHealth / 2.5f;
        info.SummonEnergy = GameInformation.PlayerEnergy;
        info.CritChance = GameInformation.CritChance + 0.05f;
        info.SummonShield = 0;
        info.CritDamage = GameInformation.CritDamage;
    }
    /// <summary>
    /// Dont forget to declear the name before this function
    /// </summary>
    /// <param name="info"></param>
    public SummonAbilites(SummonInfo info)
    {
        CalculateSummonStats(info);
    }

}
