using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : MonoBehaviour {

    private BaseWeapon newWeapon;

    // This IS BARE BONE TO HELP YOU LEARN. YOUI CAN CHANGE WEAPON DESCRIPION BUT MAKE SURE YOU ADD MULTIPLIERS WHEN THE PLAYER GETS A CERTAIN LEVEL TO CHANGE THE STATS
    void Start()
    {
        CreateWeapon();
        Debug.Log(newWeapon.ItemName);
        Debug.Log(newWeapon.ItemDescription);
        Debug.Log(newWeapon.ItemID.ToString());
        Debug.Log(newWeapon.WeaponType.ToString());
        Debug.Log(newWeapon.Stamina.ToString());
        Debug.Log(newWeapon.Endurance.ToString());
    }
    public void CreateWeapon()
    {

        newWeapon = gameObject.AddComponent <BaseWeapon>();
       // private string[] weaponNames = new string[6] array assign later

        // assign name to the weapon
        newWeapon.ItemName = "W" + Random.Range(1, 101);
        //create a weapon description
        newWeapon.ItemDescription = "This is a new weapon";
        //weapon id
        newWeapon.ItemID = Random.Range(1, 101);
        //stats
        newWeapon.Stamina = Random.Range(1, 11);
        newWeapon.Endurance = Random.Range(1, 11);
        newWeapon.Intellect = Random.Range(1, 11);
        newWeapon.Strength = Random.Range(1, 11);
        //choose type of weapon
        ChooseWeaponType();
        // spell effect id
        newWeapon.SpellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        System.Array weapon = System.Enum.GetValues(typeof(BaseWeapon.WeaponTypes));
        newWeapon.WeaponType = (BaseWeapon.WeaponTypes)weapon.GetValue(Random.Range(0, weapon.Length));
    }

}
