using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class BulletRush : MonoBehaviour {
    [HideInInspector]
    public GameObject projector;
    TeleGrams telegrams;
   
    public float range;
    public float duration;
    GameObject player;
    public GameObject bullet;
    GameObject bulletInst;
    bool hasAttacked;
    bool isWait;
    public float delay;
    bool isFinished;
    [HideInInspector]
     bool isPressed;
    public GameObject button;
    int damage;
    int baseDamage;
    
    int ID = 1;

    // Use this for initialization
    void Start()
    {
        baseDamage = 5;
        isWait = false;
        hasAttacked = false;
        isFinished = false;
        player = gameObject;
        telegrams = gameObject.GetComponent<TeleGrams>();
        isPressed = false;
        button.GetComponent<SkillBar>().globalTime = duration;
        projector = Instantiate(Resources.Load<GameObject>("Projectors/RangedAttackProjector"));
        projector.transform.parent = this.gameObject.transform;
        projector.transform.localPosition = new Vector3(0, 24, 0); // mmm 
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 90f;
        rotationVector.z = 90f;
        projector.transform.rotation = Quaternion.Euler(rotationVector);
        Init();
       
    }

    // Only for inital stuff
    private void Init()
    {
        AbilityCreatorClass abilityCreator = new AbilityCreatorClass(projector);
        var classInfo = abilityCreator.GetAbility(ID);
        Type type = classInfo.GetType();
        foreach(var f in type.GetFields().Where(f=>f.IsPublic))
        {
            if(f.Name == "range")
            {
                var temp  = f.GetValue(classInfo).ToString();
                range = int.Parse(temp);
            }
        }
        
    }
    // To calc the damage everytime
    void CalcDamage()
    {
        AbilityCreatorClass abilityCreator = new AbilityCreatorClass(projector);
        var classInfo = abilityCreator.GetAbility(ID);
        Type type = classInfo.GetType();
        foreach (var f in type.GetFields().Where(f => f.IsPublic))
        {        
            if (f.Name == "baseDamage")
            {
                var temp = f.GetValue(classInfo).ToString();               
                float temp2 = float.Parse(temp);
                damage = (int)temp2;
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (telegrams.isWaiting)
        {
            button.GetComponent<SkillBar>().isClicked = false;
        }
        isPressed = button.GetComponent<SkillBar>().isClicked;
        if (Input.GetKeyDown(KeyBinds.Instance.Ability4) && !telegrams.isWaiting || isPressed)
        {
           
            button.GetComponent<SkillBar>().isWaiting = false;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {

                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {
                    temp[i].GetComponent<SkillBar>().isClicked = false;
                   // temp[i].GetComponent<SkillBar>().canAttack = false;
                }
            }
            button.GetComponent<SkillBar>().DurationTime(duration+0.1f, false, 0);
            telegrams.AttackRange(range, projector, duration, false);
            hasAttacked = false;
            isFinished = true;
            StartCoroutine(StopAttacking());
            isPressed = false;
        }
        if (bulletInst)
        {
            //GameObject temp = GameObject.Find("Blast(Clone)");
            //Change it to a for loop, check all of the objects at once
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            for (int i = 0; i < bullets.Length; i++)
            {
                float dist = Vector3.Distance(bullets[i].transform.position, player.transform.position);
                if (dist > range * Scalar.rangeScalar)
                {
                    Destroy(bullets[i]);
                }
            }
        }
        if (isFinished && !isWait)
        {
            //Without an amount it just shoots them
            StartCoroutine(Wait());
        }

    }
    void Fire()
    {
        //GameInformation.PlayerEnergy -= 20;
        //Soon it will be subtracting from the player information.
        // for stuff like thatr
        // Creates to many of them, i have to destroy the floating text before, etc.
        //AbilityCreatorClass abilityCreator = new AbilityCreatorClass(ID, projector);
        CalcDamage();
        AbilityInformation ability = new AbilityInformation();
        ability.channelled = new ChannelledAbilities();
        bulletInst = Instantiate(bullet, GameObject.Find("BulletSpawn").transform.position, GameObject.Find("BulletSpawn").transform.rotation);
        bulletInst.transform.position = GameObject.Find("BulletSpawn").transform.position;
        bulletInst.GetComponent<Rigidbody>().velocity = bulletInst.transform.forward * 50;
        bulletInst.AddComponent<Damage>();
        bulletInst.AddComponent<AbiliyCont>();
        bulletInst.GetComponent<Damage>().SetDamage((int)ability.channelled.GetDamage(damage,(int)GameInformation.CritChance));// will change this number to a crit modifer * the scalar.
        if (GameObject.FindGameObjectWithTag("Summon"))
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Summon");
            for (int i = 0; i < temp.Length; i++)
            {
                Physics.IgnoreCollision(temp[i].GetComponent<Collider>(), bulletInst.GetComponent<Collider>());
            }
        }
        hasAttacked = true;
    }
    IEnumerator Wait()
    {
        isWait = true;
        yield return new WaitForSeconds(delay);
        isWait = false;
        Fire();
    }
    IEnumerator StopAttacking()
    {
        yield return new WaitForSeconds(duration);
        isFinished = false;
    }
}
