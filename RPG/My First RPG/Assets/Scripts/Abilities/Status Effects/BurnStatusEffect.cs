[System.Serializable]
public class BurnStatusEffect : BaseStatusEffect  {

	public BurnStatusEffect()
    {
        StatusEffectName = "Burn";
        StatusEffectDescription = "Burning for a duration";
        StatusEffectID = 1;
        StatusEffectPower = ((10 * GameInformation.Intellect*(GameInformation.MainStat/5))*(GameInformation.PlayerLevel/4));
        StatusEffectApplyPercentage = 30; // Has a 65% chance of being applied unless the ability says it will be 
        StatusEffectMinTurnApplied = 2;
        StatusEffectMaxTurnApplied = 4;
        StatusEffectStayAppliedPercentage = 25;
        duration = 8; // May be changed depending on the ability;
    }
}
