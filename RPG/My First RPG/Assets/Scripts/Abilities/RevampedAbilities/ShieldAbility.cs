using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ShieldAbility : MonoBehaviour
{
    TeleGrams telegrams;
    public float range;
    float duration;
    GameObject player;
    //public GameObject bullet;
    public GameObject shield;
    bool hasAttacked;
    bool isWait;
    bool hasDefended;
    bool isPressed;
    public GameObject button;
    [HideInInspector]
    public bool isInstant;
    //float shieldAmount;
    int ID = 4;
    
    // Use this for initialization
    void Start()
    {
        isInstant = true;
        //button.GetComponent<SkillBar>().isInstantSpell = true;
        hasDefended = false;
        isWait = true;
        hasAttacked = false;
        player = gameObject;
        telegrams = gameObject.GetComponent<TeleGrams>();
        isPressed = false;
        button.GetComponent<SkillBar>().globalTime = 0;
        button.GetComponent<SkillBar>().isInstantAbility = true;

        AbilityCreatorClass abilityCreator = new AbilityCreatorClass();
        var classInfo = abilityCreator.GetAbility(ID);
        Type type = classInfo.GetType();
        foreach (var f in type.GetFields().Where(f => f.IsPublic))
        {
            if (f.Name == "duration")
            {
                var temp = f.GetValue(classInfo).ToString();
                duration = int.Parse(temp);
                //Debug.Log(duration);
                break;
            }
        }
    }
    private void GetShieldAmount()
    {
        AbilityCreatorClass abilityCreator = new AbilityCreatorClass();
        var classInfo = abilityCreator.GetAbility(ID);
        ShieldProtectionAbility shieldProt = (ShieldProtectionAbility)classInfo;
        shieldProt.GetShieldBuff();
        Debug.Log(GameInformation.PlayerShield);

    }
    // Update is called once per frame
    void Update()
    {
        
        isPressed = button.GetComponent<SkillBar>().isClicked;
        if (Input.GetKeyDown(KeyBinds.Instance.Ability3) && button.GetComponent<SkillBar>().isFinished|| isPressed && button.GetComponent<SkillBar>().isFinished)
        {
            //telegrams.AttackRange(range, projector, duration, true);
            button.GetComponent<SkillBar>().DurationTime(0, true, duration + 4.0f);
            button.GetComponent<SkillBar>().isFinished = false;
            GetShieldAmount();
            hasAttacked = false;
            isWait = false;
            shield.SetActive(true);
            hasDefended = true;
           
            //button.GetComponent<SkillBar>().canAttack = false;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].GetComponent<SkillBar>().isClicked = false;
            }
            isPressed = false;

        }
        if (shield.activeInHierarchy && !isWait)
        {
            StartCoroutine(Destroy());
        }
        if(shield.activeInHierarchy)
        {
            if(GameInformation.PlayerShield <= 0)
            {
                StopCoroutine(Destroy());
                shield.SetActive(false);
                isWait = false;
                hasDefended = false;
            }
        }
    }
    IEnumerator Destroy()
    {
        isWait = true;
        yield return new WaitForSeconds(duration);
        shield.SetActive(false);
        isWait = false;
        hasDefended = false;
    }
    
}
