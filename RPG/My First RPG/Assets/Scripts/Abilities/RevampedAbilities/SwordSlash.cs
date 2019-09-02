[System.Serializable]
public class SwordSlash : BaseAbility {
    // LEARN DATABASE
    public SwordSlash()
    {
        AbilityName = "Sword Slash";
        AbilityDescription=" A Strong Slash";       
        AbilityID = 2;
        AbilityPower = 20;
        AbilityCost = 2;
        AbilityStatusEffects.Add(new BurnStatusEffect());
        AbilityStatusEffect = new BurnStatusEffect();
        AbilityCritChance = 85;
        AbilityCritModifer = 1.2f; 
    }
}
