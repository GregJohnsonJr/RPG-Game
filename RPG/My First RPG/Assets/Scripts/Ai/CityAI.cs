using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AIAdditions;

[RequireComponent(typeof(NavMeshAgent))]
public class CityAI : MonoBehaviour
{
    // There will be a number of different NCPS, lets give them some behaviour
    enum States
    {
        WALKAROUND,
        LOOKAROUND,
        RUNAROUND,
        STAND,
        JUMP
    }
    States states;
    [Tooltip("Is the current npc an Child")]
    public bool isKid;
    [Tooltip("Is the current npc an Adult")]
    public bool isAduilt;
    [Tooltip("Is the current npc a Merchant")]
    public bool isMerchant; // we can get more specific with the types later
    [Tooltip("Is the current npc an QuestGiver")]
    public bool isQuestGiver;
    public float runSpeed = 16f;
    public float walkSpeed = 8f;
    NavMeshAgent agent;
    public float rangeToExplore;
    Vector3 startPos;
    Vector3 exploringPos;
    float dist;
    AIExtensions aiExtra;
    System.Random rand;
    bool isExploring;
    [Range(0,100)]
    public float chanceToRun;
    [HideInInspector]
    public bool isTalking;
    Interactions interactions;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Interactions>())
            interactions = GetComponent<Interactions>();
        aiExtra = new AIExtensions();
        agent = gameObject.GetComponent<NavMeshAgent>();
        rand = new System.Random(System.Environment.TickCount);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactions)
        {
            isTalking = interactions.GetDisplay();
        }
        dist = Vector3.Distance(transform.position, startPos);
        if(!isTalking)
            StateChangeMachine();
        else
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
    }
    void StateChangeMachine()
    {
        if (!isExploring)
        {
            int num = aiExtra.FindRandonNumberBetweenTwo(chanceToRun, rand);
            if (num == 0)
            {
                states = States.RUNAROUND;
            }
            else
                states = States.WALKAROUND;
        }
        if (isMerchant)
        {
            states = States.LOOKAROUND;
        }
        if (isQuestGiver)
        {
            // For
            states = States.LOOKAROUND;
        }
            switch (states)
            {
                case States.WALKAROUND:
                    WalkAroundState();
                    break;
                case States.LOOKAROUND:
                    LookAroundState();
                    break;
                case States.RUNAROUND:
                    RunAroundState();
                    break;
                case States.JUMP:
                    JumpState();
                    break;
                case States.STAND:
                    StandState();
                    break;
            }
    }
    //NPCS are only allowed to stand and lookARound

    void WalkAroundState() //  This state will make the npc walk around its area
    {
       if(dist < rangeToExplore && !isExploring)
       {
            //Find random postion and move them to that position
            Vector3 rand = aiExtra.FindRandomPosition(startPos, rangeToExplore);
            agent.destination = rand;
            agent.speed = walkSpeed;
            isExploring = true;
       }
       if(agent.remainingDistance <= 0.4f)
        {
            isExploring = false;
        }
    }
    void RunAroundState() // this state will make the npc run to random areas. If they are a kid they hae a higher change of running to different areas --Excludes NPCS
    {
        if (dist < rangeToExplore && !isExploring)
        {
            //Find random postion and move them to that position
            Vector3 rand = aiExtra.FindRandomPosition(startPos, rangeToExplore);
            agent.destination = rand;
            agent.speed = runSpeed;
            isExploring = true;
        }
        if (agent.remainingDistance <= 0.4f)
        {
            isExploring = false;
        }        
    }
    bool turnAround;
    void LookAroundState() // This state will make the npc stop and look around its area --Merchants manly
    {
        if (transform.eulerAngles.y < 45f && !turnAround)
            transform.Rotate(transform.up, .15f);
        else
        {
            transform.Rotate(-transform.up, .15f);
            turnAround = true;
            if(transform.eulerAngles.y <= 1f)
            {
                turnAround = false;
            }
        }

        
    }
    void JumpState()// This state will make the npc jump if it is scared or if it needs to go over gaps
    {

    }
    void StandState()// This state will allow the npc to stand in one location "Mimics thinking" Usually Merchants will do this
    {

    }
}
