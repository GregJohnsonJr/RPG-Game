using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    int classNum;
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Each number corresponds with a different class
    /// 0 Mage
    /// 1 Warrior
    /// 2 Archer
    /// 3 Rouge
    /// 4 Priest
    /// 5 Warlock
    /// 6 Paladin
    /// 7 Enhancer
    /// </summary>
    /// <param name="num"></param>
    void SelectedClass(int isClassSelection)
    { // Since they are being set equal to a new class, we should be fine
        if (isClassSelection == 0)
        {
            GameInformation.PlayerClass = new BaseMageClass();
        }
        else if (isClassSelection == 1)
        {
            GameInformation.PlayerClass = new BaseWarriorClass();
        }
        else if (isClassSelection == 2)
        {
            GameInformation.PlayerClass = new BaseArcherClass();

        }
        else if (isClassSelection == 3)
        {
            GameInformation.PlayerClass = new BaseRougeClass();

        }
        else if (isClassSelection == 4)
        {
            GameInformation.PlayerClass = new BasePriestClass();

        }
        else if (isClassSelection == 5)
        {
            GameInformation.PlayerClass = new BaseWarlockClass();
        }
        else if (isClassSelection == 6)
        {
            GameInformation.PlayerClass = new BasePaladinClass();

        }
        else if (isClassSelection == 7)
        {            
            GameInformation.PlayerClass = new BaseEnhancerClass();
        }
        
    }
    public void SetClassNum(int num)
    {
        classNum = num;
    }
    public void Back()
    {
        // Grab all buttons and turn them off
        panel.SetActive(!panel.activeInHierarchy);
    }
    public void Next()
    {
        // Grab all buttons and turn them on
        panel.SetActive(!panel.activeInHierarchy);
        SelectedClass(classNum);
    }
    void SetArrayActiveOrDisabled(ActionEvents[] a)
    {
        foreach(ActionEvents b in a)
        {
            b.gameObject.SetActive(!b.gameObject.activeInHierarchy);
        }
    }
}
