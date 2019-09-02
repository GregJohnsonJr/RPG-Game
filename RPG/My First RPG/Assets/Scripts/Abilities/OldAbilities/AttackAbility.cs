[System.Serializable]

public class AttackAbility : BaseAbility {
    //This is the base ability template
    // Use this to make abilites, and find them, hmmmm.
	public AttackAbility()
    {
        AbilityName = "Normal Attack";
        AbilityDescription = "Uses your main weapon to attack";
        AbilityID = 1;
        AbilityPower = 10;
        AbilityCost = 5;
        AbilityCritChance = 5;
    }
}
