using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPotion : MonoBehaviour {

    private BasePotion newPotion;
	// Update is called once per frame
	void Start () {
        CreatePotion();
        Debug.Log(newPotion.ItemName);
        Debug.Log(newPotion.ItemDescription);
        Debug.Log(newPotion.ItemID);
        Debug.Log(newPotion.PotionType);
    }
    private void CreatePotion()
    {
        newPotion = gameObject.AddComponent<BasePotion>();
        newPotion.ItemName = "Potion";
        newPotion.ItemDescription = "This is a Potion";
        newPotion.ItemID = Random.Range(1, 101);
        ChoosePotionType();
    }

    private void ChoosePotionType()
    {
        System.Array potions = System.Enum.GetValues(typeof(BasePotion.PotionTypes));
        newPotion.PotionType = (BasePotion.PotionTypes)potions.GetValue(Random.Range(0, potions.Length));
        Debug.Log(newPotion.PotionType);
    }
}
