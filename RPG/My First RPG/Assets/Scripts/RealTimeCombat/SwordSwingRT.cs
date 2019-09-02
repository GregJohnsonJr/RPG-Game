using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordSwingRT : MonoBehaviour
{
    public Texture2D[] picture;
    public float zoom = 20;
    public float normal = 60;
    public float smooth = 5;
    public float rotationSpeed = 20;
    public KeyCode key;
    GameObject Weapon;
    private bool ZoomedIn = false, ZoomedBack = false;
    public Animation swordSwing;
    bool isClicked = false;
    bool isSet = false;
    NewActionBarScript action;
    [HideInInspector]
    public static int damage;
    bool isCooldown = false;
    public GameObject player;
    public float duration;
    public GameObject slash;
    float distance;
    TeleGrams teleGrams;
    [HideInInspector]
    public GameObject projector;
    bool hasAttacked;
    public float range;
    GameObject swordInsti;
    GameObject temp;
    bool isPressed;
    public GameObject button;


    public void Start()
    {
        //action = GameObject.FindGameObjectWithTag("Gui").GetComponent<NewActionBarScript>();      
        ZoomedIn = false;
        ZoomedBack = false;
        isClicked = false;
     //   damage = GameInformation.playerMoveTwo.AbilityPower;      
        teleGrams = player.GetComponent<TeleGrams>();
        hasAttacked = true;
        isPressed = false;
        button.GetComponent<SkillBar>().globalTime = duration;
        projector = Instantiate(Resources.Load<GameObject>("Projectors/MeleeAttackArea"));
        projector.transform.parent = this.gameObject.transform;
        projector.transform.localPosition = new Vector3(0, 24, 2); // mmm
        projector.SetActive(false);
        //ani.GetComponent<Animator>();

        //player = transform.parent.gameObject;
    }

    public void Update()
    {
        // cap the sword at 90, once it reaches 90, make it so it it reverts back and waits for a certain command to be true;
        if (!isSet)
        {
            //key = action.skill[0].key;
            //isSet = true;
        }
        if(teleGrams.isWaiting)
        {
            button.GetComponent<SkillBar>().isClicked = false;
        }

        isPressed = button.GetComponent<SkillBar>().isClicked;
        if (Input.GetKeyDown(KeyBinds.Instance.Abilitiy1) && !teleGrams.isWaiting || isPressed && !teleGrams.isWaiting) //Input.GetKeyDown(key) || // Basically the telegrams
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
            button.GetComponent<SkillBar>().DurationTime(duration, false, 0);
            
            //GameInformation.PlayerEnergy -= GameInformation.playerMoveTwo.AbilityCost;
            //Debug.Log(GameInformation.PlayerEnergy);
            isClicked = true;
           // swordSwing.Play();
            smooth = 10;

            teleGrams.AttackRange(range, projector, duration, false);
            hasAttacked = false;
            //will change this to be the range, every attack will have this
            //StartCoroutine(DisableProjector());
            isPressed = false;
        }

        if (swordInsti)
        {
            //GameObject temp = GameObject.Find("Bullet(Clone)");
            float dist = swordInsti.transform.position.magnitude - player.transform.position.magnitude;
            if (dist > range * Scalar.rangeScalar)
            {
                Destroy(swordInsti);
            }

        }

        if (ZoomedIn == true)
        {
            transform.Rotate(Vector3.forward * smooth);
        }
        if (transform.eulerAngles.z >= 90)
        {
            //   Debug.Log("Passed 90");
            ZoomedIn = false;
            ZoomedBack = true;
        }
        if (ZoomedBack)
        {
            // Debug.Log("Going Back");
            transform.Rotate((Vector3.back * rotationSpeed) * Time.deltaTime);
        }
        if (transform.eulerAngles.z <= 3)
        {
            //Debug.Log("Passed 0");
            ZoomedBack = false;
            ZoomedIn = false;
            int tempzero = 0;
            smooth = tempzero;
        }
        if (transform.eulerAngles.z > 350)
        {
            // Debug.Log("Passed 0");
            ZoomedBack = false;
            ZoomedIn = false;
            int tempzero = 0;
            smooth = tempzero;
        }

        if (teleGrams.isDone && !hasAttacked)
        {
            //Without an amount it just shoots them
            Slash();

        }

    }
    /* IEnumerator DisableProjector()
     {
         isCooldown = true;
         yield return new WaitForSeconds(duration);
         Fire();
         yield return new WaitForSeconds(0.2f);
         isCooldown = false;


     }*/
    void Slash()
    {
        //temp = Instantiate(slash);
        //temp is the parent
        temp = slash.transform.parent.gameObject;
        temp.SetActive(true);
        //slash.transform.parent.gameObject.SetActive(true);
        //slash.SetActive(true);
        slash.GetComponent<ParticleSystem>().Play();
        hasAttacked = true;
        StartCoroutine(Destroy());

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.4f);
        slash.GetComponent<ParticleSystem>().Stop();
        temp.SetActive(false);
        //slash.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Hit");
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag != "Player" && hit.collider.tag != "Terrain")
        {

            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("Hit");

            }
        }
    }



}
