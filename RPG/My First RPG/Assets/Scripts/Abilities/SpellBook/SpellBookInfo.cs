using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Reflection;

//Should I create a database??

public class SpellBookInfo : MonoBehaviour
{
    
    public int spellCount;
    public int whereIDStarts;
    public GameObject informationHolder;
    public GameObject abilityInfo;
    int damage;
    string abilityName;
    // I need to think of a way to dynamically get all the spells in the book for what they are, i think that will
    // Come later when i have a whole class of spells implemented.
    void Start()
    {
        SetUpSpellBook();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void SetUpSpellBook() // We might just create and destroy this? hmm
    {
        for (int i = whereIDStarts; i < whereIDStarts + spellCount; i++)
        {


            AbilityCreatorClass abilityCreator = new AbilityCreatorClass(); // This will create the summonInfo Dynically
            var classInfo = abilityCreator.GetAbility(i);
            Type type = classInfo.GetType();
            SpellStatsInformation spells = new SpellStatsInformation();
            GameObject temp = Instantiate(informationHolder);
           
            temp.transform.parent = this.transform;
            spells.ID = i;
            foreach (var f in type.GetFields().Where(f => f.IsPublic))
            {
                Debug.Log(f.Name);
                if (f.Name == "title")
                {
                    //  The main name of the ability
                    spells.title = f.GetValue(classInfo).ToString() ;
                }
                if (f.Name == "description")
                {
                    // The description of the ability
                    spells.description = f.GetValue(classInfo).ToString();
                    Debug.Log(spells.description);
                }
                if (f.Name == "type")
                {
                    // The type of ability
                    spells.type = f.GetValue(classInfo).ToString();
                }
            }

            temp.GetComponentInChildren<Text>().text = spells.title;
            temp.GetComponent<SpellBookButtonScript>().description = spells.description;
            temp.GetComponent<SpellBookButtonScript>().ID = spells.ID;
            temp.GetComponent<SpellBookButtonScript>().abilityInformation = abilityInfo;
        }
    }
}
public class SpellStatsInformation
{
    public string title;
    public string description;
    public string type;
    public int ID;
   public  SpellStatsInformation() { }
}
