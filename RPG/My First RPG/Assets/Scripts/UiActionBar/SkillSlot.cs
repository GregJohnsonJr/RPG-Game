using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Obsolete]
[System.Serializable]
public class SkillSlot {
// OutDated
    public SwordSwingRT skill;
    public Rect postion;
    public KeyCode key;
    // Use this for initialization
   
    public void SetKey(KeyCode keyCode)
    {
        if(skill != null)
        {
            skill.key = keyCode;
            key = keyCode;
        }
        
    }
        
}
