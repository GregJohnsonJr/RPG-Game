using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class BlastAttack : MonoBehaviour {
    [HideInInspector]
    public GameObject projector;
    TeleGrams telegrams;
    public float range;
    public float duration;
    GameObject player;
    public GameObject bullet;
    GameObject bulletInst;
    bool hasAttacked;
    public GameObject button;
    bool isPressed;
    int damage;
    int baseDamage;
    int ID;
    
	// Use this for initialization
	void Start () {
        ID = 2;
        isPressed = false;
        hasAttacked = true;
        player = gameObject;
        projector = Instantiate(Resources.Load<GameObject>("Projectors/RangedAttackProjector"));
        projector.transform.parent = this.gameObject.transform;
        projector.transform.localPosition = new Vector3(2, 24, 0); // mmm
        telegrams = gameObject.GetComponent<TeleGrams>();
        button.GetComponent<SkillBar>().globalTime = duration;       
        Init();
    }
    // Only for inital stuff
    private void Init()
    {
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
    void Update () {
        if (telegrams.isWaiting)
        {
            button.GetComponent<SkillBar>().isClicked = false;
        }
        isPressed = button.GetComponent<SkillBar>().isClicked;
        if (Input.GetKeyDown(KeyBinds.Instance.Ability2) && !telegrams.isWaiting || isPressed && !telegrams.isWaiting)
        {
            // the damage for this attack is based on intellect and mastery + the main stat of your character.         
            
            button.GetComponent<SkillBar>().isWaiting = false;
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < temp.Length; i++)
            {

                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {
                    temp[i].GetComponent<SkillBar>().isClicked = false;
                    //temp[i].GetComponent<SkillBar>().canAttack = false;
                }
            }
            button.GetComponent<SkillBar>().DurationTime(duration, false, 0);
            telegrams.AttackRange(range, projector, duration, false);
            hasAttacked = false;
            isPressed = false;
        }
        if (bulletInst)
        {
            //GameObject temp = GameObject.Find("Blast(Clone)");
            float dist = bulletInst.transform.position.magnitude - player.transform.position.magnitude;
            if (dist > range * Scalar.rangeScalar)
            {
                Destroy(bulletInst);
            }

        }
        if (telegrams.isDone && !hasAttacked)
        {
            //Without an amount it just shoots them
            Fire();

        }

    }
    void Fire()
    {
        CalcDamage();
        AbilityInformation ability = new AbilityInformation();
        ability.blast = new BlastAbilities();
        bulletInst = Instantiate(bullet, GameObject.Find("BulletSpawn").transform.position, GameObject.Find("BulletSpawn").transform.rotation);
        bulletInst.transform.position = GameObject.Find("BulletSpawn").transform.position;
        bulletInst.GetComponent<Rigidbody>().velocity = bulletInst.transform.forward * 50;
        bulletInst.AddComponent<Damage>();
        bulletInst.GetComponent<Damage>().SetDamage((int)ability.blast.GetDamage(damage,(int)GameInformation.CritChance));
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
}
