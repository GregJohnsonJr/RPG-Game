using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interfaces : MonoBehaviour {
}
public interface AbilityCreation
{
    int range
    {
        get;
        set;
    }
    TeleGrams telegram
    {
        get;
        set;
    }
    GameObject projector
    {
        get;
        set;
    }

    void Init();
    /*{
      AbilityCreatorClass abilityCreator = new AbilityCreatorClass(projector);
        var classInfo = abilityCreator.GetAbility(ID);
        Type type = classInfo.GetType();
        foreach (var f in type.GetFields().Where(f => f.IsPublic))
        {
            if (f.Name == "range")
            {
                var temp = f.GetValue(classInfo).ToString();
                range = int.Parse(temp);
            }
        }
    }*/


}
