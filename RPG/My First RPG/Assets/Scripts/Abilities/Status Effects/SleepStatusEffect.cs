[System.Serializable]
public class SleepStatusEffect : BaseStatusEffect {

    public SleepStatusEffect()
    {
        StatusEffectName = "Sleep";
        StatusEffectDescription = "Target Falls a sleep for a few turns";
        StatusEffectID = 1;
        StatusEffectPower = 0;
        StatusEffectApplyPercentage = 100; // Has a 65% chance of being applied
        StatusEffectMinTurnApplied = 1;
        StatusEffectMaxTurnApplied = 3;
        StatusEffectStayAppliedPercentage = 30;
        duration = 45;
        //staying applied variable
    }
}
public class ParalyzedStatusEffect : BaseStatusEffect
{

    public ParalyzedStatusEffect()
    {
        StatusEffectName = "Paralyzed";
        StatusEffectDescription = "Target is Paralyzed for a duration";
        StatusEffectID = 1;
        StatusEffectPower = 0;
        StatusEffectApplyPercentage = 100; // Has a 65% chance of being applied
        StatusEffectMinTurnApplied = 1;
        StatusEffectMaxTurnApplied = 3;
        StatusEffectStayAppliedPercentage = 30;
        duration = 15;
        //staying applied variable
        // For real time combat there are no turns
    }
}
public class StunStatusEffect : BaseStatusEffect
{

    public StunStatusEffect()
    {
        StatusEffectName = "Stun";
        StatusEffectDescription = "Target is Stunned for a few seconds";
        StatusEffectID = 1;
        StatusEffectPower = StatusEffectPower = ((10 * GameInformation.Strength * (GameInformation.MainStat / 6)) * (GameInformation.PlayerLevel / 4)); ;
        StatusEffectApplyPercentage = 100; // Has a 65% chance of being applied
        StatusEffectMinTurnApplied = 1;
        StatusEffectMaxTurnApplied = 3;
        StatusEffectStayAppliedPercentage = 30;
        duration = 4;
        //staying applied variable
    }
}
public class BleedStatusEffect : BaseStatusEffect
{

    public BleedStatusEffect()
    {
        StatusEffectName = "Bleeding";
        StatusEffectDescription = "Target is Bleeding for a few seconds";
        StatusEffectID = 1;
        StatusEffectPower = StatusEffectPower = ((10 * GameInformation.Agility * (GameInformation.MainStat / 4)) * (GameInformation.PlayerLevel / 4)); ;
        StatusEffectApplyPercentage = 100; // Has a 25% chance of being applied stated other wisea
        StatusEffectMinTurnApplied = 1;
        StatusEffectMaxTurnApplied = 3;
        StatusEffectStayAppliedPercentage = 30;
        duration = 12;
        //staying applied variable
    }
}
public class FrozenStatusEffect : BaseStatusEffect
{

    public FrozenStatusEffect()
    {
        StatusEffectName = "Frozen";
        StatusEffectDescription = "Target is Frozen for a duration";
        StatusEffectID = 1;
        StatusEffectPower = StatusEffectPower = ((2.5f * GameInformation.Intellect * (GameInformation.MainStat / 4)) * (GameInformation.PlayerLevel / 4)); ;
        StatusEffectApplyPercentage = 15; // Has a 15% chance of being applied
        StatusEffectMinTurnApplied = 1;
        StatusEffectMaxTurnApplied = 3;
        StatusEffectStayAppliedPercentage = 30;
        duration = 12;
        //staying applied variable
    }
}


