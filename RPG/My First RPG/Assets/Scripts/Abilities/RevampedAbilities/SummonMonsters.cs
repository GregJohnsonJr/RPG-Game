using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SummonMonsters : MonoBehaviour
{
    GameObject summon;
    private SummonInfo summonInfo;
    GameObject circleProjector;
    [Tooltip("The Id for priest summons are 5 - 10, enhancer summons are 10- 15")]
    public int iD; // Should I make it so the name of the abilites check for the id of the names...
    int range;
    string name;
    bool choosePosition;
    bool isHovering;
    TeleGrams tele;
    private void Start()
    {
        isHovering = false;
        choosePosition = false;
        circleProjector = Instantiate(Resources.Load<GameObject>("Projectors/CircleAttackProjector"));
        circleProjector.transform.position = transform.position;
        circleProjector.SetActive(false);
        

    }
    public void Init(int ID)
    {
        GameObject projector = null;
        GameObject healProjector = null;
        AbilityCreatorClass abilityCreator = new AbilityCreatorClass(); // This will create the summonInfo Dynically
        var classInfo = abilityCreator.GetAbility(ID);
        Type type = classInfo.GetType();
        summonInfo = new SummonInfo();
        int damage = 0;
        int duration = 0;
        foreach (var f in type.GetFields().Where(f => f.IsPublic))
        {
            if(f.Name == "baseDamage")
            {
                var temp = f.GetValue(classInfo).ToString();
                damage = int.Parse(temp);               
            }
            if (f.Name == "range")
            {
                var temp = f.GetValue(classInfo).ToString();
                range = int.Parse(temp);
            }
            if (f.Name == "info")
            {
                var temp = f.GetValue(classInfo) as SummonInfo;
                summonInfo = temp;
            }
            if (f.Name == "name")
            {
                name = f.GetValue(classInfo).ToString();
            }
            if(f.Name == "attackProjector")
            {
                var temp = f.GetValue(classInfo).ToString();
                projector = Instantiate(Resources.Load<GameObject>("Projectors/" + temp));
                projector.name = temp;
            }
            if (f.Name == "healProjector")
            {
                var temp = f.GetValue(classInfo) as GameObject;
                healProjector = temp;
            }
            if(f.Name == "duration")
            {
                var temp = f.GetValue(classInfo).ToString();
                duration = int.Parse(temp);
            }
        }
        GameInformation.SummonsUp++;
        summonInfo.SummonName = name;
        summon = Instantiate(Resources.Load<GameObject>("Summons/" + name));
        projector.transform.parent = summon.transform;
        summon.transform.position = new Vector3(circleProjector.transform.position.x, transform.position.y, circleProjector.transform.position.z);
        projector.transform.position = new Vector3(summon.transform.position.x,projector.transform.position.y+20f,summon.transform.position.z);
        //projector.transform.rotation = new Vector3(summon.transform.rotation.x, projector.transform.rotation.y);
        var rotationVector = summon.transform.rotation.eulerAngles;
        rotationVector.x = 90f;
        rotationVector.z = 90f;
        projector.transform.rotation = Quaternion.Euler(rotationVector);
        if (projector != null)
            summon.GetComponent<SummonsAi>().SetDamageProjector(projector);
        if(healProjector != null)
            summon.GetComponent<SummonsAi>().SetHealProjector(healProjector);
        summon.GetComponent<SummonsAi>().baseDamage = summonInfo.BaseDamage;
        summon.GetComponent<SummonsAi>().attackRange = range;
        summon.GetComponent<SummonsAi>().duration = duration;
        summonInfo.CalculateEnergy();
        summonInfo.CalculateHealth();
        summonInfo.CalculateCrit();
        summonInfo.CalculateDamage(damage);
        summon.GetComponent<SummonsAi>().SetSummonInfo(summonInfo);
        Debug.Log(summonInfo.HealAmount);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyBinds.Instance.Ability5) && GameInformation.SummonsUp < 2)
        {
            choosePosition = true;
        }
        if (choosePosition)
        {

            isHovering = true;
            choosePosition = false;
        }
        if (isHovering)
        {
            //Plane plane = new Plane(Vector3.up, 0);
            // float distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
            //Vector3 screenPos = Camera.mainz.ScreenToWorldPoint(Input.mousePosition+Vector3.forward*10+ Vector3.up*400);
            //screenPos.y = transform.position.y + 100f;
            //circleProjector.transform.position = screenPos;
            // Mouse z position is increasing the opposite y, same with x pos.
            circleProjector.SetActive(true);
            Vector3 screenPoint;
            Vector3 offset;
            screenPoint = Camera.main.WorldToScreenPoint(Input.mousePosition);
            // Debug.Log(screenPoint.z);
            offset = Input.mousePosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z + 600f);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint);
            //Debug.Log(cursorPosition);
            float dist = Vector3.Distance(cursorPosition, transform.position);
            //Debug.Log(dist);
            if (Vector3.Distance(cursorPosition, transform.position) < (6 * Scalar.summonRange) * 3f)
            {
                circleProjector.transform.position = cursorPosition;
            }
            //transform.position = cursorPosition;

        }
        if (isHovering && Input.GetMouseButtonDown(0))
        {
            Init(iD);
            circleProjector.SetActive(false);
            isHovering = false;
        }
    }
}
