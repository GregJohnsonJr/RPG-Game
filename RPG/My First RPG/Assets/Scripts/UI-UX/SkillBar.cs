using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillBar : MonoBehaviour, IPointerClickHandler {
    public int abilityNum;
    Button button;
    public float globalTime;
    [HideInInspector]
    public bool isCoolDown;
    Color newColor;
    ColorBlock orgColor;
    [HideInInspector]
    public bool isWaiting = false;
    [HideInInspector]
    public bool isClicked = false;
    [HideInInspector]
    public bool isInstantSpell = false;
    KeyCode key;
    float coolDownTime;
    [HideInInspector]
    public bool isFinished = true;
    [HideInInspector]
    public bool isInstantAbility;
    [HideInInspector]
    public bool canAttack;
    bool isChecking;
    // Have to add a method to on click where a function is called
    // Give the function a timer so it only happens once.
    // Have to improve the art of the skill bar (easy)
    // Have to add fancy effects so people know when its on cooldown, and when its not
    void Awake()
    {
        isInstantAbility = false;
    }
    void Start()
    {
        canAttack = true;
        newColor = Color.gray;
        isCoolDown = false;
        button = gameObject.GetComponent<Button>();
        orgColor = button.colors;
        isFinished = true;
        isChecking = false;
        Initialized();
    }
    private void Initialized()
    {
        // We are going to use the parent to get the number for it... 
        if (abilityNum == 1)
        {
            key = KeyBinds.Instance.Abilitiy1;
        }
        else if (abilityNum == 2)
        {
            key = KeyBinds.Instance.Ability2;
        }
        else if (abilityNum == 3)
        {
            key = KeyBinds.Instance.Ability3;
        }
        else if (abilityNum == 4)
        {
            key = KeyBinds.Instance.Ability4;
        }
        else if (abilityNum == 5)
        {
            key = KeyBinds.Instance.Ability5;
        }
        else if (abilityNum == 6)
        {
            key = KeyBinds.Instance.Ability6;
        }
        else if (abilityNum == 7)
        {
            key = KeyBinds.Instance.Ability7;
        }
    }
    // Update is called once per frame
    // FINALLY GOTT IT WORKING RIGHT
    void Update()
    {
        
        if(Input.GetKeyDown(key) && !isWaiting)
        {
            GlobalCooldown();
        }
        if(button.colors != orgColor && isChecking)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = newColor;
            button.colors = cb;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {

                    //temp[i].GetCompone nt<SkillBar>().isWaiting = true;
                    temp[i].GetComponent<Button>().colors = cb;
                }

            }
            button.colors = cb;
        }
        else if(isChecking)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = newColor;
            button.colors = cb;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {

                    //temp[i].GetCompone nt<SkillBar>().isWaiting = true;
                    temp[i].GetComponent<Button>().colors = cb;
                }

            }
            button.colors = cb;
        }
        //UpdatedButtonBasedOnCase();
    }
    void UpdatedButtonBasedOnCase()
    {
        if (!canAttack)
        {
            Debug.Log("coolingDown");
            ColorBlock cb = button.colors;
            cb.normalColor = newColor;
            button.colors = cb;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {
                   
                    //temp[i].GetCompone nt<SkillBar>().isWaiting = true;
                    temp[i].GetComponent<Button>().colors = cb;
                }

            }
        }
        else if(canAttack)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {

                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {
                    
                    // temp[i].GetComponent<SkillBar>().isWaiting = false;
                    temp[i].GetComponent<Button>().colors = orgColor;
                }
            }
        }
    }
    void GlobalCooldown()
    {
        if (!isInstantSpell)
        {
            isClicked = true;
            ColorBlock cb = button.colors;
            cb.normalColor = newColor;
            button.colors = cb;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {
                    temp[i].GetComponent<SkillBar>().isCoolDown = true;
                    //temp[i].GetComponent<SkillBar>().isWaiting = true;
                    //temp[i].GetComponent<Button>().colors = cb;
                }
            }
            //UpdatedButtonBasedOnCase();
            if (!isCoolDown)
            {
                Debug.Log("Hit" + "" + gameObject.name);
            }
            if (!isWaiting)
            {
                StopCoroutine(Wait());
                StartCoroutine(Wait());
            }
        }
        else if(isInstantSpell)
        {
            isClicked = true;
            
            DefensiveInstantSpell();
        }

    }
    void DefensiveInstantSpell()
    {
       
        ColorBlock cb = button.colors;
        cb.normalColor = newColor;
        button.colors = cb;
        button.GetComponent<Button>().colors = cb;
     
        StartCoroutine(InstantCoolDown());
    }
    
    /// <summary>
    /// if you set instant to true, the spell will become a instant with cd.
    /// </summary>
    /// <param name="time"></param>
    /// <param name="isDefensive"></param>
    public void DurationTime(float time, bool isInstant, float coolDown)
    {
        //We are going to set it equal to the Global CoolDown
        globalTime = time;
        isInstantSpell = isInstant;
        coolDownTime = coolDown;
        GlobalCooldown();
    }
    IEnumerator InstantCoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        button.colors = orgColor;
        isFinished = true;
        isClicked = false;

    }
    // SO WHEN I USE AN ABILITY THE BAR GRAYS OUT BEFORE THE ATTACK WITH A DELAY THEN COMES BACK AFTER THE ATTACKS STARTS.. very werid
    // Fix that immedantly tommorrow!
    IEnumerator Wait()
    {
        //Controls global Cooldowns

          isWaiting = true;
        ColorBlock cb = button.colors;
        cb.normalColor = newColor;
        button.colors = cb;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < temp.Length; i++)
        {
            if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
            {
                temp[i].GetComponent<SkillBar>().isCoolDown = false;
                // temp[i].GetComponent<SkillBar>().isWaiting = false;
                //temp[i].GetComponent<Button>().colors = cb;
                //temp[i].GetComponent<SkillBar>().canAttack = false;
                temp[i].GetComponent<SkillBar>().isWaiting = true;
            }
        }
        canAttack = false;
        if(!isInstantAbility)
        isChecking = true;
        yield return new WaitForSeconds(globalTime +0.6f);
        isWaiting = false;
        
        //GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < temp.Length; i++)
        {
            if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
            {
                temp[i].GetComponent<SkillBar>().isCoolDown = false;
                // temp[i].GetComponent<SkillBar>().isWaiting = false;
                temp[i].GetComponent<Button>().colors = orgColor;
                temp[i].GetComponent<SkillBar>().canAttack = true;
                temp[i].GetComponent<SkillBar>().isWaiting = false;
            }
        }
        //UpdatedButtonBasedOnCase();
        if (!isInstantAbility)
        {
            button.colors = orgColor;
            isChecking = false;
        }
        else
        {

            yield return new WaitForSeconds(coolDownTime);
            button.colors = orgColor;

            isFinished = true;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isWaiting)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = newColor;
            button.colors = cb;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {

                    //temp[i].GetCompone nt<SkillBar>().isWaiting = true;
                    //temp[i].GetComponent<Button>().colors = cb;
                }

            }
            GlobalCooldown();
        }
    }
    public void Clicked()
    {
        if(!isWaiting)
        { 
           GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {
                  
                    temp[i].GetComponent<SkillBar>().canAttack = false;
                }
            }
            UpdatedButtonBasedOnCase();
        }
       
    }
}


