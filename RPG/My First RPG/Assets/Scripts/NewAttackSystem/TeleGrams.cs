using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleGrams : MonoBehaviour {


    // Use this for initialization
    //A public method that grabs the range of the skill...
    GameObject pro;
    float durationTime;
    [HideInInspector]
    public bool isDone;
    GameObject player;
    Vector3 orgPos;
    
    [HideInInspector]
    public bool isWaiting;
    bool isDef = false;
    void Start()
    {       
        isDone = false;
        player = GameObject.FindGameObjectWithTag("Player");
        isWaiting = false;
    }

   //TO USE THIS
   // YOUR SCRIPT MUST HAVE A SCRIPT THAT USES THE ISDONE TO INITATE THE ATTACK
   // You must have some boolean that does not allow the attack to spam(unless channelled)
   // You must make sure there is a cooldown
   // Dont forget to pass the duration of the attack, the range, and the projector you are going to use
   // Will have multiple shapes of projectors in the future.
   // Make sure you multiply the range of the attack Times the multiple 5.15 to destroy it when it gets to the end of the telegram
   // The Scalar for the range of attack is 3.1
   // Dont forget to destroy the object after it leaves the range with the range multipler
   // AND WE SHOULD BE GUCCI!!!
   // I wonder if it would be easier for the abilities to all derive from on script and or editor?
   // If so i might be easier to create the abilities...
    public void AttackRange(float range, GameObject projector, float duration, bool isDefensive)
    {
        //I have to draw out the ground some way.
        //I have to allow detection on the things on the ground..
        //Add effects to them so you know when they go off...
        //Instantiate them from the player
        //Would i use a graphic? Draw something? I need to represent some things in arc so it might be easier to draw them.
        //Projectors might be the goat, lets learn more about them to create shadows of the area
        //Need to define an area, and get some shaders, etc.
        //Actually,lol particle systems would be so much easier
        // LOl no use projectors
        //aspectRatio is range
        //Size is for big aoe
        //Maybe I should make it so you can cancel your attack and cast another one.
        //Would have to add another bool
        isWaiting = true;
        isDef = isDefensive;
        if (!isDefensive)
        {
            orgPos = projector.transform.localPosition;
            if (projector.transform.parent != null && projector.transform.parent.tag == player.tag)
                projector.transform.localPosition += new Vector3(0, 0, (range * Scalar.distanceScalar) * -1);
            else if (projector.name == "MeleeAttackArea")
            {
                projector.transform.localPosition += new Vector3(0, 0, ((range - 1) * Scalar.distanceScalar) * 1);
                
            }
            else if (projector.name == "RangedAttackProjector")
            {
                projector.transform.localPosition += new Vector3(0, 0, (range * Scalar.distanceScalar) * 1);
                if (projector.transform.localPosition.z > (range * Scalar.distanceScalar))
                {
                    projector.transform.localPosition = new Vector3(projector.transform.localPosition.x, projector.transform.localPosition.y, range * Scalar.distanceScalar);
                }
            }
            durationTime = duration;
            pro = projector;
            projector.SetActive(true);
            projector.GetComponent<Projector>().aspectRatio = range;
        }
        //have to add offset
        StartCoroutine(DisableProjector());
        
    }
    IEnumerator DisableProjector()
    {
        if (pro.transform.parent == player)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Button");
            Color newColor = Color.gray;
            ColorBlock cb = temp[0].GetComponent<Button>().colors;
            cb.normalColor = newColor;

            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].GetComponent<SkillBar>().isInstantAbility)
                {

                    //temp[i].GetCompone nt<SkillBar>().isWaiting = true;
                    temp[i].GetComponent<Button>().colors = cb;
                }

            }
        }
        yield return new WaitForSeconds(durationTime+0.3f);
        isDone = true;
        yield return new WaitForSeconds(0.2f);
        if (!isDef)
        {
            pro.transform.localPosition = orgPos;
            pro.SetActive(false);
        }
        isDone = false;
        isWaiting = false;       
    }
}


