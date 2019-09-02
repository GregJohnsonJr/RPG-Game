using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewActionBarScript : MonoBehaviour {
    /// <summary>
    /// OBSOLETE!! WE DONT USE THIS SCRIPT ANYMORE
    /// </summary>
    public SkillSlot[] skill;
    public Texture2D actionBar;
    public Rect postion; 
    public float skillX, skillY, skillWidth, skillHeight;
    public float skillDistance;
   
	// Use this for initialization
	void Start () {
        //skill = new SkillSlot[1];
        Initialize();
	}
    void Initialize()
    {
        // When we get more moves, add more
        SwordSwingRT rt = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordSwingRT>();
        LightningAttack light = GameObject.FindGameObjectWithTag("Sword").GetComponent<LightningAttack>();
        PlasmaBeamAttack plasma = GameObject.FindGameObjectWithTag("Sword").GetComponent<PlasmaBeamAttack>();

        skill = new SkillSlot[3];

        for (int i = 0; i < skill.Length; i++)
        {
            skill[i] = new SkillSlot();          
            skill[i].skill = rt;
           
       }
        skill[0].SetKey(KeyCode.Q);
        skill[1].SetKey(KeyCode.E);
        skill[2].SetKey(KeyCode.R);
    }
    // Update is called once per frame
    void Update () {

        updateSkillSlots();
	}
    void updateSkillSlots()
    {// Change to length soon
        for (int i = 0; i < skill.Length; i++)
        {
             skill[i].postion.Set(skillX + i *(skillWidth + skillDistance), skillY, skillWidth, skillHeight);
            
        }
      


    }
    void OnGUI()
    {
        DrawActionBar();
        DrawSkillSlots();

    }
    void DrawActionBar()
    {

        GUI.DrawTexture(GetScreenRect(postion), actionBar);
    }
    void DrawSkillSlots()
    {
        for (int i = 0; i < skill.Length; i++)
        {
            GUI.DrawTexture(GetScreenRect(skill[i].postion), skill[i].skill.picture[i]);
            


        }

    }
    Rect GetScreenRect(Rect postion)
    {
        return new Rect(Screen.width * postion.x, Screen.height * postion.y, Screen.width * postion.width, Screen.height * postion.height);

    }
}
