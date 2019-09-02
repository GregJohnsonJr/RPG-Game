using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInformation {
    public SwordAbilities sword;
    public BlastAbilities blast;
    public ChannelledAbilities channelled;
    public BuffAbilities buff;
    public SustainedAbilities sustained;
    public AbilityInformation() { }
}
public class SwordAbilities : AbilityInformation // For Sword Attacks, Damage values and etc is going to be here
{
    int damage;
    int baseDamage = 3 * (GameInformation.PlayerLevel / 14);
    int damageModifyer = GameInformation.MainStat * (int)Scalar.damageMultiple;
    int baseCritChance = (int)GameInformation.CritChance;
    /// <summary>
    /// baseDamageAddictive is the Attacks base Damage.
    /// The crit will be the GameInformation.CritChance Depending on if the attack is magical or not..
    /// </summary>
    /// <param name="baseDamageAdditive"></param>
    /// <param name="crit"></param>
    /// <returns></returns>
    public float GetDamage(int baseDamageAdditive, int crit)// Damage Additive will be the damage with the main stats of that effect the abilities. 
    {
        crit += baseCritChance;
        int random = Random.Range(0, 100);
        if(random <= crit)
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseDamage * damageModifyer;
            return (damage + baseDamageAdditive) * (2f + (GameInformation.CritDamage)); // Crit Calculation Set!
        }
        else
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseDamage * damageModifyer;
            return damage + baseDamageAdditive;
        }      
    }
    public float GetEnemyDamage(int baseDamageAdditive, int crit, EnemyInformation enemy)// Damage Additive will be the damage with the main stats of that effect the abilities. 
    {
        int baseEneDamage = 3 * (enemy.PlayerLevel / 4);
        crit += baseCritChance;
        int random = Random.Range(0, 200);
        if (random <= crit)
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseEneDamage * 2;
            Debug.Log(damage);
            return (damage + baseDamageAdditive) * (2f); // Crit Calculation Set!
        }
        else
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseEneDamage * 2;
            Debug.Log(damage);
            return damage + baseDamageAdditive;
        }
    }
}
public class BlastAbilities : AbilityInformation // For Single Target big attacks, or single target blast attacks
{
    int damage;
    int baseDamage = 4 * (GameInformation.PlayerLevel / 12);
    int damageModifyer = GameInformation.MainStat * (int)Scalar.damageMultiple;
    int baseCritChance = 7;
    /// <summary>
    ///  baseDamageAddictive is the Attacks base Damage.
    /// The crit will be the GameInformation.CritChance Depending on if the attack is magical or not..
    /// </summary>
    /// <param name="baseDamageAdditive"></param>
    /// <param name="crit"></param>
    /// <returns></returns>
    public float GetDamage(int baseDamageAdditive, int crit)// Damage Additive will be the damage with the main stats of that effect the abilities.
    {
        crit += baseCritChance;
        int random = Random.Range(0, 100);
        if (random <= crit)
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseDamage * damageModifyer;
            return (damage + baseDamageAdditive) * (2f + (GameInformation.CritDamage));// Crit Damage Calculation
        }
        else
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseDamage * damageModifyer;
            return damage + baseDamageAdditive;
        }
    }
    public float GetEnemyDamage(int baseDamageAdditive, int crit, EnemyInformation enemy)// Damage Additive will be the damage with the main stats of that effect the abilities. 
    {
        int baseEneDamage = 4 * (enemy.PlayerLevel / 4);
        crit += baseCritChance;
        damageModifyer = (enemy.MainStat * (int)Scalar.damageMultiple)/20;
        int random = Random.Range(0, 200);
        if (random <= crit)
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseEneDamage * damageModifyer;
           // Debug.Log(damage);
            return (damage + baseDamageAdditive) * (2f); // Crit Calculation Set!
        }
        else
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseEneDamage * damageModifyer;
            Debug.Log(damage);
            return damage + baseDamageAdditive;
        }
    }

}
public class ChannelledAbilities : AbilityInformation // For Channelled abilities that will constantly do stuff
{
    int damage;
    int baseDamage = 2 * ((GameInformation.PlayerLevel / 15)+1);
    int damageModifyer = GameInformation.MainStat * (int)Scalar.damageMultiple;
    int baseCritChance = 5;
    /// <summary>
    /// baseDamageAddictive is the Attacks base Damage.
    /// The crit will be the GameInformation.CritChance Depending on if the attack is magical or not..
    /// </summary>
    /// <param name="baseDamageAdditive"></param>
    /// <param name="crit"></param>
    /// <returns></returns>
    public float GetDamage(int baseDamageAdditive, int crit)// Damage Additive will be the damage with the main stats of that effect the abilities.
    {
        crit += baseCritChance;
        int random = Random.Range(0, 100);
        if (random <= crit)
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseDamage * damageModifyer;
            return (damage + baseDamageAdditive) *(2f + (GameInformation.CritDamage));
        }
        else
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseDamage * damageModifyer;
            return damage + baseDamageAdditive;
        }
    }
    public float GetEnemyDamage(int baseDamageAdditive, int crit, EnemyInformation enemy)// Damage Additive will be the damage with the main stats of that effect the abilities. 
    {
        int baseEneDamage = 2 * (enemy.PlayerLevel / 4);
        crit += baseCritChance;
        int random = Random.Range(0, 200);
        damageModifyer = enemy.MainStat * (int)Scalar.damageMultiple;
        if (random <= crit)
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseEneDamage * damageModifyer;
            Debug.Log(damage);
            return (damage + baseDamageAdditive) * (2f); // Crit Calculation Set!
        }
        else
        {
            float temp = baseDamageAdditive * 0.3f;
            baseDamageAdditive = (int)temp;
            damage = baseEneDamage * damageModifyer;
            Debug.Log(damage);
            return damage + baseDamageAdditive;
        }
    }
}
public class BuffAbilities : AbilityInformation // For buffs
{
    float duration;
    public enum BuffTtype
    {
        STRENGTH,
        INTELLECT,
        MASTERY,
        RESISTANT,
        AGILITY,
        STAMINA,
        ENDURANCE,
        PLAYERHEALTH,
        PLAYERENERGY,
        SHIELD
    };
    public BuffTtype buffType;
    /// <summary>
    /// Buff type is the type of buff.
    /// Percent Increase is the amount you want to buff by
    /// And time is the duration of the buff in seconds.
    /// Going to add a piece of it for the ui
    /// </summary>
    /// <param name="tempBuff"></param>
    /// <param name="percentIncrease"></param>
    /// <param name="time"></param>
    public void SetCase(BuffTtype tempBuff, float percentIncrease, int time)
    {
        Debug.Log(tempBuff);
        switch (tempBuff)
        {
            case BuffTtype.AGILITY:
                AgiCase(percentIncrease, time);
                break;
            case BuffTtype.ENDURANCE:
                EnduranceCase(percentIncrease, time);
                break;
            case BuffTtype.INTELLECT:
                IntellectCase(percentIncrease, time);
                break;
            case BuffTtype.MASTERY:
                MasteryCase(percentIncrease, time);
                break;
            case BuffTtype.PLAYERENERGY:
                PlayerEnergyCase(percentIncrease, time);
                break;
            case BuffTtype.PLAYERHEALTH:
                PlayerHealthCase(percentIncrease, time);
                break;
            case BuffTtype.RESISTANT:
                ResistantCase(percentIncrease, time);
                break;
            case BuffTtype.STAMINA:
                StaminaCase(percentIncrease, time);
                break;
            case BuffTtype.STRENGTH:
                StrengthCase(percentIncrease, time);
                break;
            case BuffTtype.SHIELD:
                ShieldCase(percentIncrease, time);
                break;
        }
// Lets send a case to the playerScript
    }
    void AgiCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Agility * percentIncrease;
        GameInformation.BuffedAgility += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Agility", (((int)temp)));
        // I should add a prefab that is instaniated as a buff 
    }
    void EnduranceCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Endurance * percentIncrease;
        GameInformation.BuffedEndurance += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Endurance", (((int)temp)));
    }
    void IntellectCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Intellect * percentIncrease;
        GameInformation.BuffedIntellect += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Intellect", (((int)temp)));
    }
    void MasteryCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Mastery * percentIncrease;
        GameInformation.BuffedMastery += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Mastery", (((int)temp)));
    }
    void PlayerEnergyCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.PlayerEnergy * percentIncrease;
        GameInformation.BuffedPlayerEnergy += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Energy", (((int)temp)));
    }
    void PlayerHealthCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.PlayerHealth * percentIncrease;
        GameInformation.BuffedPlayerHealth += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Health", (((int)temp)));
    }
    void ResistantCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Resistance * percentIncrease;
        GameInformation.BuffedResistance += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Resistance", (((int)temp) * GameInformation.PlayerLevel));
    }
    void StaminaCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Stamina * percentIncrease;
        GameInformation.BuffedStamina += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Stamina", (((int)temp)));
    }
    void StrengthCase(float percentIncrease, int time)
    {
        float temp = (float)GameInformation.Strength * percentIncrease;
        GameInformation.BuffedStrength += (((int)temp));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();        
        player.SetBuffDuration(time, "Strength", (((int)temp)));
    }
    void ShieldCase(float percentIncrease, int time)
    {
        //Shield cannot be greater then hp, and shield will be a percentage of your hp
        float temp = (float)GameInformation.PlayerHealth * percentIncrease;
        GameInformation.PlayerShield += (((int)temp));
        //Debug.Log((((int)temp)));
        BasePlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        player.SetBuffDuration(time, "Shield", (((int)temp)));
    }
}
public class SustainedAbilities : AbilityInformation // For sustainedAbilities such as heals and damage reduction
{
    float healingDone = (GameInformation.Intellect * 0.65f)*GameInformation.PlayerLevel;
    int baseCritChance = 5;
    public int GetHealing(int crit)
    {
        crit += baseCritChance;
        int random = Random.Range(0, 100);
        if (random <= crit)
            return (int)healingDone;
        else
            return (int)healingDone;
    }


}