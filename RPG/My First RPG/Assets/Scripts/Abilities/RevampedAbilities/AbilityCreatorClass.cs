using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

// This class is used to create prototype abilities to be used inside the game
// In this class you can create a ability with an id, damage, effects, and everything you need for it.
// The abilitys you can create are limitless as long as you can program the actual ability you want.
// Point and click abilitys will be created next and we will go from there for the next ones.
// Every ability will need a range, and a id. The ID will be used to trace and grab every ability.
// I will put every ability in a list so I can know what the information is for that ability when i need to grab it.
// You will also be able to tweak and improve every ability to your liking in this class, we use 
// objects to send back to the programmed abilities to grab the information for the ability.
// You are also allowed to send back strings for resources loads to dynamically load gameobjects



// THE POSSIBILITES ARE ENDLESS
public enum SpellTypes
{
    BUFF,
    ATTACK,
    SUMMON
}
public class AbilityCreatorClass
{
    public BulletRushAbility bulletRushAbility;
    public BlastAttackAbility blastAttackAbility;
    public GameObject project;
    /// <summary>
    /// Every Ability will have a different ID, ill make a return id class so I can just grab the id based on 
    /// name later
    /// Depending on the id you enter, that will create a new class based on that ability that will give you
    /// all the information based on the ability
    /// </summary>
    /// <param name="abilityID"></param>
    public AbilityCreatorClass(GameObject projector)
    {
        //Debug.Log(GetAbility(1).ToString());
        //Debug.Log(GetAbility(2).ToString());
        //Debug.Log(GetAbility(3).ToString());
        //Debug.Log(GetAbility(4).ToString());
        project = projector;
    }
    /// <summary>
    /// Id is never 0, as for projectors... We are going to have to have to set them from the object.
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public object GetAbility(int ID)
    {
        // This is a way to make dynamic classes without knowing the type
        // I use the system reflection namespace to grab the asseblys and create the object
        // Then i return the object and grab the values via script.. Actually pretty cool
        var list = FindSubClasses().ToList();
        // Make is so i can just throw in a id, and it will automatically make a new class                                    // and use the projector with the constructor....
        object item;
        var myType = list.ElementAt(ID - 1);
        //Type type = Type.GetType(myType.ToString());
        item = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(myType.ToString(), true);
        var temp = item;
        return temp;
        // will return an ability based on id.
    }
    IEnumerable<Type> FindSubClasses()
    {
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in asm.GetTypes())
            {
                if (type.BaseType == this.GetType())
                {
                    yield return type;
                }
            }
        }
    }
    public AbilityCreatorClass() { }
    public AbilityCreatorClass(string stringAddress) { }
}

// Add a description for spellbook
public class BulletRushAbility : AbilityCreatorClass // <- like a volley of arrows
{
    int ID = 1;
    public float baseDamage = (5 + (GameInformation.Mastery * 3) + (GameInformation.Agility * 7)) * UnityEngine.Random.Range(0.94f, 0.98f); // Some calculation
    public float critChance = 0.03f;
    public int range = 6;
    GameObject projector;
    public BulletRushAbility(GameObject project)
    {
        projector = project;
    }
    public BulletRushAbility() { }
    public string title = "Bullet Rush";
    public string description = " You call forth many bulllets in order to shoot your enemies";
    public string type = "Attack";
}
public class BlastAttackAbility : AbilityCreatorClass // <- like a fireball
{
    int ID = 2;
    public float baseDamage = (20 + (GameInformation.Mastery * 4) + (GameInformation.Intellect * 15)) * UnityEngine.Random.Range(0.94f, 0.98f); // Some calculation
    public float critChance = 0.08f;
    public int range = 6;
    GameObject projector;
    public BlastAttackAbility(GameObject project)
    {
        projector = project;
    }
    public BlastAttackAbility()
    { }
    public string title = "Blast Attack";
    public string description = " You shot your enemy with a single bullet attack";
    public string type = "Attack";
}
public class SwordSlashAbility : AbilityCreatorClass //<- Basic Sword attack
{
    int ID = 3;
    public float baseDamage = (10 + (GameInformation.Mastery * 4) + (GameInformation.Strength * 20)) * UnityEngine.Random.Range(0.94f, 0.98f); // Some calculation
    public float critChance = 0.08f;
    public int range = 1;
    GameObject projector;
    public SwordSlashAbility(GameObject project)
    {
        projector = project;
    }
    public SwordSlashAbility()
    { }
    public string title = "Sword Slash";
    public string description = " Lash out at your enemies with a sword slash.";
    public string type = "Attack";
}
public class ShieldProtectionAbility : AbilityCreatorClass //<- Basic Shield Abilities
{
    // The shield does not use a projector as it is a instant ability and just applies shield to you
    int ID = 4;
    public int shieldValue;
    public int duration = 5;
    GameObject projector;
    public AbilityInformation ability;
    public ShieldProtectionAbility() { }
    public void GetShieldBuff()
    {
        ability = new AbilityInformation();
        ability.buff = new BuffAbilities();
        ability.buff.SetCase(BuffAbilities.BuffTtype.SHIELD, 0.3f, duration);
    }
    public string title = "Shield";
    public string description = "Defend yourself from incoming damage.";
    public string type = "Buff";
    // Will create a shield for a short amount of time...   
}
// Maybe derive a projector class
// Also will add classes to the abilities
// Going to add a interface so we know what class this belongs to.
public class SummonTurretAbility : AbilityCreatorClass, EnhancerClass
{
    // This summon is stationary
    int ID = 5;
    public int baseDamage = (int)((10 + (GameInformation.Mastery * 6) + (GameInformation.Intellect * 13)) * UnityEngine.Random.Range(0.94f, 0.98f)); // Some calculation
    public float critChance = 0.08f; // <- will be depended on Character Crit
    public int range = 6;
    public int summonRange = 9;
    public int duration = 60; // <- after this duration it dissapears...Only for stationary summons
    public SummonInfo info;
    public string name = "Turret";
    public string attackProjector = "RangedAttackProjector";
    // No heal projector in this one
    public SummonTurretAbility()
    {
        info = new SummonInfo();
        SummonAbilites abilites = new SummonAbilites(info);
    }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Summon Turrent";
    public string description = " You create a turrent that will stand by you in combat.";
    public string type = "Summon";
}
// Healing Turret
public class HealingTurretAbility : AbilityCreatorClass, EnhancerClass
{
    int ID = 6;
    public int baseDamage = (int)((10 + (GameInformation.Mastery * 6) + (GameInformation.Intellect * 10)) * UnityEngine.Random.Range(0.94f, 0.98f)); // Some calculation
    public int healingDone = (int)((10 + (GameInformation.Mastery * 3) + (GameInformation.Intellect * 7)) * UnityEngine.Random.Range(0.94f, 0.98f)); // Some calculation
    public float critChance = 0.08f; // <- will be depended on Character Crit
    public int range = 6;
    public int summonRange = 9;
    public int duration = 60; // <- after this duration it dissapears...Only for stationary summons
    public SummonInfo info;
    public string name = "HealTurret"; // <- Have to make another turret and name it heal with the correct presets. Thank god I made an ai for everything
    public string attackProjector = "RangedAttackProjector"; // going to be more then one projector later for certian abilites
                                                             // No heal projector in this one
    public HealingTurretAbility()
    {
        info = new SummonInfo();
        SummonAbilites abilites = new SummonAbilites(info);
    }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Healing Turrent";
    public string description = "Allows you to summon out a turret that will heal you.";
    public string type = "Summon";

}
public class HealingAttackTurret : AbilityCreatorClass, EnhancerClass
{
    int ID = 7;
    public int healingDone = (int)((10 + (GameInformation.Mastery * 2) + (GameInformation.Intellect * 5)) * UnityEngine.Random.Range(0.94f, 0.98f)); // Some calculation
    public float critChance = 0.08f; // <- will be depended on Character Crit
    public int range = 6;
    public int summonRange = 9;
    public int duration = 60; // <- after this duration it dissapears...Only for stationary summons
    public SummonInfo info;
    public string name = "HealAttackTurret"; // <- Have to make another turret and name it heal with the correct presets. Thank god I made an ai for everything
    public string attackProjector = "RangedAttackProjector"; // going to be more then one projector later for certian abilites
                                                             // No heal projector in this one
    public HealingAttackTurret()
    {
        info = new SummonInfo();
        SummonAbilites abilites = new SummonAbilites(info);
        info.HealingCalc(healingDone);
        //Debug.Log(info.HealAmount);
    }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Healing and Attack Turrent";
    public string description = "Allows you to summon out a turret that will heal you." +
    "The type of healing will differ will in different power suits, from burst, sustained, AoE, etc.";
    public string type = "Summon";
}
public class LaserBeam : AbilityCreatorClass, EnhancerClass // <- continually damage ab
{
    int ID = 8;
    public float baseDamage = (20 + (GameInformation.Mastery * 4) + (GameInformation.Intellect * 15)) * UnityEngine.Random.Range(0.94f, 0.98f); // Some calculation
    public float critChance = 0.08f;
    public int range = 6;
    GameObject projector;
    public LaserBeam(GameObject project)
    {
        projector = project;
    }
    public LaserBeam()
    { }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Laser Beam";
    public string description = " Fires a beam of light towards his enemy.";
    public string type = "Attack";
}

public class PowerSuitZero : AbilityCreatorClass, EnhancerClass // every suit will have strengths and weakness to balance it out, expect for the first suit
{
    int ID = 9;
    public int buffedIntellect = 30 * GameInformation.PlayerLevel;
    public int damageAdditive = 150 * GameInformation.PlayerLevel; // <- add that too summonInfo for all summons.
    public int range = 0;
    GameObject projector;
    public PowerSuitZero()
    { }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Power Suit Zero";
    public string description = "This powersuit, increases your magical damage and has no elemental effects.";
    public string type = "Buff";
}
public class WaterPowerSuit : AbilityCreatorClass, EnhancerClass
{
    int ID = 10;
    public int buffedIntellect = 15 * GameInformation.PlayerLevel;
    public int damageAdditive = 100 * GameInformation.PlayerLevel; // <- add that too summonInfo for all summons.
    public bool isAOE = true;
    public float aoeRadius = 1.5f;
    public string waterProj = "WaterBomb"; // <- or something like that
                                           //Basically make all the turrets attacks make a watery explosion on impact
    public int range = 0;
    GameObject projector;
    public WaterPowerSuit()
    { }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Water Power Suit";
    public string description = "While the water suit is equipped your turrets do water-based attacks that hit in an AoE." +
        " Your healing turret also heals in an aoe when this is equipped, and your main attacks also deal bonus water damage";
    public string type = "Buff";
}
public class LightningPowerSuit : AbilityCreatorClass, EnhancerClass
{
    int ID = 11;
    AbilityInformation ability;
    public int buffedAgility = 10 * GameInformation.PlayerLevel; // <- add that too summonInfo for all summons.
    public int buffedIntellect = 20 * GameInformation.PlayerLevel;
    public int damageAdditive = 100 * GameInformation.PlayerLevel;
    public int nerfedHealth = (int)(GameInformation.PlayerHealth * 0.15f); // 15% of health is gone subtract this from maxHp
    public string lightningPaths = "LightningProj"; // So we can find the lightning prefab
                                                    //Basically makes your turrets shoot out electricity for sustained damage
    public int range = 0;
    public LightningPowerSuit()
    { }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Lightning Power Suit";
    public string description = "Equip yourself with a lightning suit, which increases your agility." +
        "It causes all your attacks to do a small bit of extra lightning damage, and your turrets shoot sustained lightning towards the target.";
    public string type = "Buff";
}
public class EarthPowerSuit : AbilityCreatorClass, EnhancerClass
{
    int ID = 12;
    AbilityInformation ability;
    public int buffedHealth = 40 * GameInformation.PlayerLevel;
    public float damageDecrease = 0.9f;
    public float speedDecrease = 0.95f;
    // <- add that too summonInfo for all summons.
    // Your attacks slow the targets
    public float slowAmount = 0.2f;
    public string earthPaths = "EarthAttack";
    public int range = 0;
    public EarthPowerSuit()
    { }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Earth Power Suit";
    public string description = "This is suit makes you more tanky by increasing your max health and resistance but lowers your damage and speed.";
    public string type = "Buff";
}
public class FinalSpark : AbilityCreatorClass // <- like a fireball
{
    int ID = 13;
    public float baseDamage = (20 + (GameInformation.Mastery * 10) + (GameInformation.Intellect * 26)) * UnityEngine.Random.Range(0.94f, 0.98f); // Some calculation
    public float critChance = 0.1f;
    public int range = 6;
    public bool isAOE = true;
    public float aoeRadius = 2;
    GameObject projector;
    public FinalSpark(GameObject project)
    {
        projector = project;
    }
    public FinalSpark()
    { }
    public void AddAbilityToClass()
    {
        BaseEnhancerClass.abilities.Add(this);
    }
    public string title = "Final Spark";
    public string description = "A high tier magic attack that deals massive damage towards the target but has a long cast time.";
    public string type = "Attack";
}

