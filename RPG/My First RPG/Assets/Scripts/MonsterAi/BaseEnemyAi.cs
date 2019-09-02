using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAi : MonoBehaviour {
    bool isAgentSearching = false;
    NavMeshAgent agent;
    GameObject player;
    public float aggroRange;
    TeleGrams tele;
    public GameObject projector;
    BaseEnemyScript baseEnemy;
    public GameObject bullet;
    GameObject bulletInst;
    bool isAttacking;
    EnemyInformation enemy;
    GameObject orgLocation;
    public float attackRange;
    public int range;
    public float searchArea;
    public int attackDistance;
    bool isRefreshed;
    bool isWaiting;
    GameObject temp;
    [Tooltip("For Melee Ai")]
    public GameObject slash;
    public bool isMelee;
    public bool isRanged;
    bool delayForAttack;
    Vector3 orgPos;
    public enum MeleeStates
    {
        WAITING,
        AGGRO,
        ATTACK,
        RAGE,
        RETREAT,
        FALLBACK
    };
    MeleeStates states;
	// Use this for initialization
	void Start () {
        delayForAttack = false;
        isRefreshed = false;
        enemy = gameObject.GetComponent<EnemyInformation>();
        baseEnemy = gameObject.GetComponent<BaseEnemyScript>();
        //baseEnemy.CalculateEnemyInfo(2, 1);
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        tele = gameObject.GetComponent<TeleGrams>();
        isAttacking = false;
        orgLocation = Instantiate(new GameObject());
        orgLocation.transform.position = transform.position;
        isWaiting = false;
        orgPos = projector.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        DetermineMoveBasedOnState();      
	}
    void DetermineMoveBasedOnState()
    {
        float dist = Vector3.Distance(player.transform.position,transform.position);
        if (dist > aggroRange && states != MeleeStates.WAITING)
        {
            states = MeleeStates.FALLBACK;
            
        }
        if (dist <= aggroRange && !isWaiting)
        {
            states = MeleeStates.AGGRO;
            
        }
        if (orgLocation != null && Vector3.Distance(orgLocation.transform.position, transform.position) > 50)
        {
            // He has to fall back after he loses sight of you.
            states = MeleeStates.FALLBACK;
            
        }
        if(dist < attackRange && !isWaiting)
        {
            states = MeleeStates.ATTACK;
         
        }
        if (gameObject)
        {
            switch (states)
            {
                case MeleeStates.AGGRO:
                    if (agent.isStopped)
                    {
                        agent.isStopped = false;
                    }
                    isRefreshed = true;
                    transform.LookAt(player.transform);
                    AggroState();
                    break;
                case MeleeStates.ATTACK:
                    transform.LookAt(player.transform);
                    if (isRanged) //For ranged, make them appear at a range near the player
                    {
                        if (Vector3.Distance(player.transform.position, transform.position) < attackDistance) // <- Going to be attack range
                        {
                            agent.isStopped = true;
                        }
                        else
                            agent.isStopped = false;
                    }
                    else if(isMelee)
                    {
                        if (Vector3.Distance(player.transform.position, transform.position) < attackDistance) // <- Going to be attack range
                        {
                            agent.isStopped = true;
                        }
                        else
                            agent.isStopped = false;
                    }
                    agent.destination = player.transform.position;
                    AttackState();
                    break;
                case MeleeStates.WAITING:
                    isRefreshed = true;
                    WaitingState();
                    break;
                case MeleeStates.FALLBACK:
                    isRefreshed = true;
                    if (!isWaiting)
                        StartCoroutine(WaitBeforeAttack(10f)); //Maybe i should make it so it just has to return to its org pos instead of a timer...
                    FallBack();
                    break;
            }
        }
    }
    void AggroState()
    {
            agent.destination = player.transform.position;
       
        if(isRanged) //For ranged, make them appear at a range near the player
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 10)
            {
                agent.isStopped = true;
            }
            else
                agent.isStopped = false;
        }
    }
    void AttackState()
    {
        if (!delayForAttack)
        {
            //attack, probably will just shoot something rn
            if (!tele.isDone && !isAttacking)
            {
                tele.AttackRange(range, projector, 2, false);
                isAttacking = true;
            }
            if (tele.isDone && isAttacking)
            {
                if (isMelee)
                    Slash();
                else if (isRanged)
                    Fire();
                isAttacking = false;
                StartCoroutine(Wait(1f));
            }
            else if (isRefreshed)
            {
                isAttacking = false;
                isRefreshed = false;
            }
        }

        //Damage damage = new Damage();

    }
    void WaitingState()
    {
        if (!isAgentSearching)
        {
            NavMeshHit hit;
            Vector3 point = Random.insideUnitSphere * searchArea;
            point += transform.position;
            NavMesh.SamplePosition(point, out hit, searchArea, 1);
            Vector3 finalPos = hit.position;
            agent.destination = finalPos;
            StartCoroutine(WaitForAgent());
        }
    }
    void FallBack()
    {
        if (gameObject && orgLocation)
        {
            float dist = Vector3.Distance(transform.position, orgLocation.transform.position);
            agent.destination = orgLocation.transform.position;
            if (agent.remainingDistance < 5)
            {
                states = MeleeStates.WAITING;
            }
        }
    }
    void Fire()
    {
        AbilityInformation ability = new AbilityInformation();
        ability.blast = new BlastAbilities();
        GameObject bulletSpawn = transform.GetChild(1).gameObject;
        bulletSpawn.tag = "EnemyProj";
        // Going to be on enemy change this.
        bulletInst = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bulletInst.transform.position = bulletSpawn.transform.position;
        bulletInst.GetComponent<Rigidbody>().velocity = bulletInst.transform.forward * 50;
        bulletInst.AddComponent<Damage>();
        bulletInst.GetComponent<Damage>().SetDamage((int)ability.blast.GetEnemyDamage(30, 2, enemy));
        //Debug.Log("Once");
        //bulletInst.GetComponent<Damage>().SetDamage((enemy.MainStat*enemy.PlayerLevel)*enemy.Agility);
    }
    void Slash()
    {
        //temp = Instantiate(slash);
        //temp is the parent
        temp = slash.transform.parent.gameObject;
        temp.SetActive(true);
        //slash.transform.parent.gameObject.SetActive(true);
        //slash.SetActive(true);
        slash.GetComponent<ParticleSystem>().Play();
        //isAttacking = true;
        StartCoroutine(Destroy());

    }
    IEnumerator Wait(float seconds)
    {
        delayForAttack = true;
        yield return new WaitForSeconds(seconds);      
        delayForAttack = false;
    }
    IEnumerator WaitBeforeAttack(float seconds)
    {
        isWaiting = true;
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.4f);
        slash.GetComponent<ParticleSystem>().Stop();
        temp.SetActive(false);
        //slash.SetActive(false);
    }
    IEnumerator WaitForAgent()
    {
        isAgentSearching = true;
        yield return new WaitForSeconds(8f);
        isAgentSearching = false;
    }
}
