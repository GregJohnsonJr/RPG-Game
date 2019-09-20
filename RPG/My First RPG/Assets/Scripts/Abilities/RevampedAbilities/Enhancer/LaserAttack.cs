using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class LaserAttack : MonoBehaviour{
    public GameObject laserBeam;
    public GameObject player;
    public GameObject projector;
    public float duration;
    public int range;
    TeleGrams telegrams;
    bool setPos = false;
    int damage;
    int ID = 8;
    bool hasAttacked;

    // Use this for initialization
    void Start () {
        Init();
        telegrams =  gameObject.GetComponent<TeleGrams>();
        projector = Instantiate(Resources.Load<GameObject>("Projectors/RangedAttackProjector"));
        projector.transform.parent = this.gameObject.transform;
        projector.transform.localPosition = new Vector3(0, 24, 0); // mmm 
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 90f;
        rotationVector.z = 90f;
        projector.transform.rotation = Quaternion.Euler(rotationVector);
    }
    
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
            if (f.Name == "baseDamage")
            {
                var temp = f.GetValue(classInfo).ToString();
                float temp2 = float.Parse(temp);
                damage = (int)temp2;
            }
        }

    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyBinds.Instance.Ability6) && !telegrams.isWaiting)
        {
          
           // laserBeam.SetActive(true);
            //Change the scale with the range, have to figure out the scalar
          
            setPos = true;
            hasAttacked = false;
            telegrams.AttackRange(range, projector, duration, false);
            
        }
        if(setPos)
        {
            laserBeam.transform.localPosition = transform.position; // + offset
        }
        if(telegrams.isDone && !hasAttacked)
        {
            hasAttacked = true;
            GameObject temp = Instantiate(laserBeam);
           // Debug.Log("here");an
            temp.transform.localScale = new Vector3(temp.transform.localScale.x, temp.transform.localScale.y, range * Scalar.rangeScalar);
            Vector3 vec = temp.GetComponent<LineRenderer>().GetPosition(1);
            vec.z = range * Scalar.rangeScalar;
            temp.GetComponent<LineRenderer>().SetPosition(1, vec);
            var rotationVector = temp.transform.rotation.eulerAngles;
            //rotationVector.x = 90f;
             rotationVector.z = 180f;
            temp.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}
