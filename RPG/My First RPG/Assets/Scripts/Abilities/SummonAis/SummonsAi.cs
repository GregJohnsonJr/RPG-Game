using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SummonsAi : MonoBehaviour
{
    [Tooltip("If the summon does not move")]
    public bool isStationary;
    [Tooltip("Do you attacks heal or does the summon heal and attack")]
    public bool isAttackHeals;
    [Tooltip("If the summon attacks")]
    public bool isAttacker;
    [Tooltip("If The summon heals")]
    public bool isHealer;
    [Tooltip("If the summon can taunt enemies")]
    public bool canTaunt;
    [Tooltip("Delay for attacks/heals")]
    public float delayInterval;
    [Tooltip("How fast is the summon")]
    public int moveSpeed;
    [Tooltip("Speed at which you move when you attack")]
    public int attackMoveSpeed;
    [Tooltip("Range at which you attack the enemy from")]
    public int attackRangeFromEnemy;
    [Tooltip("Range at which you attack the heal from")]
    public int healRangeFromAlly;
    [HideInInspector]
    public int attackRange;
    [HideInInspector]
    public SummonInfo summon;
    TeleGrams tele;
    GameObject lookAt;
    NavMeshAgent agent;
    Button button; // instanitate buttons above the skillbar
    GameObject attackProjector; // WIll add more depending on the ability.   
    GameObject healProjector;
    bool isAttacking;
    bool isWaiting;
    GameObject bulletInst;
    public GameObject projectile;
    public GameObject healprojectile;
    GameObject healInst;
    [HideInInspector]
    public float baseDamage;
    GameObject summoner;
    bool isRefreshed;
    bool isDying;
    float percent;
    [HideInInspector]
    public float duration;
    [HideInInspector]
    public GameObject channelledProj;
    public enum SummonStates
    {
        PASSIVE,
        WAIT,
        AGGRESSIVE,
        ATTACK,
        FOLLOW,
        HEAL,
        TAUNT
    };
    SummonStates state;
    void Start()
    {
        isDying = false;
        if (!gameObject.GetComponent<NavMeshAgent>())
        {
            gameObject.AddComponent<NavMeshAgent>();
            agent = gameObject.GetComponent<NavMeshAgent>();
        }
        if (!gameObject.GetComponent<TeleGrams>())
        {
            gameObject.AddComponent<TeleGrams>();
            tele = gameObject.GetComponent<TeleGrams>();
        }

        summoner = GameObject.FindGameObjectWithTag("Player");
        state = SummonStates.WAIT;
        isRefreshed = false;
        summon.SummonLevel = GameInformation.PlayerLevel;
        agent.speed = moveSpeed;
    }
    public void SetSummonInfo(SummonInfo sum)
    {
        summon = sum;
    }
    public void SetHealProjector(GameObject projector)
    {
        healProjector = projector;
    }
    public void SetDamageProjector(GameObject projector)
    {
        attackProjector = projector;
    }
    // Update is called once per frame
    void Update()
    {
        if (summon.SummonHealth > 0)
        {
            if (isAttacker && isHealer)
            {
                if(channelledProj && state != SummonStates.ATTACK && channelledProj.activeInHierarchy)
                {
                    channelledProj.SetActive(false);
                }
                HealAndAttackSummonAiController();
            }
            else if (isAttacker)
            {
                if (channelledProj && state != SummonStates.ATTACK && channelledProj.activeInHierarchy)
                {
                    channelledProj.SetActive(false);
                }
                AttackSummonAiController();
            }
            else if (isHealer)
            {
                HealSummonAiController();
            }
            if (state == SummonStates.ATTACK && lookAt != null)
            {
                transform.LookAt(lookAt.transform);
            }
        }
        else if (summon.SummonHealth <= 0)
        {
            if (!isDying)
                StartCoroutine(Wait());
        }
        if (isStationary && duration > 0)
        {
            duration -= Time.deltaTime;
            int timeLeft = (int)duration;
            Debug.Log(timeLeft);
            if (timeLeft <= 0)
            {
                summon.SummonHealth = 0;
            }
        }
    }
    IEnumerator Wait()
    {
        isDying = true;
        // Will be there destroy animation.. we are going to wait for the animation here
        yield return new WaitForSeconds(2f);
        if (GameInformation.SummonsUp > 0)
            GameInformation.SummonsUp -= 1;
        Destroy(this.gameObject);
    }
    void GetPercent()
    {
        float hp = 0;
        hp = summoner.GetComponent<XpBarGain>().GetMaxHp();
        Debug.Log(hp);
        percent = GameInformation.PlayerHealth / hp;
        Debug.Log(percent);

    }
    void HealSummonAiController()
    {
        //Because they can only heal, they only need to be able to heal, wait, or follow there summoner
        GetPercent();
        if (percent < 0.9f)
        {
            state = SummonStates.HEAL;
            Debug.Log("Heal");
        }
        else if (percent >= 1)
        {
            state = SummonStates.PASSIVE;
        }
        if (state == SummonStates.AGGRESSIVE || state == SummonStates.ATTACK)
        {
            state = SummonStates.PASSIVE;
            Debug.Log("Not Heal");
        }
        switch (state)
        {
            case SummonStates.PASSIVE:
                PassiveState();
                break;
            case SummonStates.FOLLOW:
                PassiveState();
                break;
            case SummonStates.HEAL:
                HealTarget();
                break;
            case SummonStates.WAIT:
                Waiting();
                break;
        }
    }
    void HealAndAttackSummonAiController() // <- in this state either the monsters attacks will heal or the monster heals and attacks
    {
        if (isAttackHeals)
        {
            switch (state)
            {
                case SummonStates.FOLLOW:
                    agent.isStopped = false;
                    agent.speed = moveSpeed;
                    FollowState();
                    break;
                case SummonStates.PASSIVE:
                    agent.speed = moveSpeed;
                    PassiveState();
                    break;
                case SummonStates.WAIT:
                    agent.speed = moveSpeed;
                    Waiting();
                    break;
                case SummonStates.AGGRESSIVE:
                    agent.speed = moveSpeed;
                    agent.isStopped = false;
                    AgressiveState();
                    break;
                case SummonStates.ATTACK:
                    agent.speed = attackMoveSpeed;
                    agent.isStopped = false;
                    AttackState();
                    break;
            }
        }
        else
        {
            GetPercent();
            if (percent < 0.9f)
            {
                state = SummonStates.HEAL;
                Debug.Log("Heal");
            }
            else if (percent >= 1)
            {
                state = SummonStates.PASSIVE;
            }
            if (state == SummonStates.AGGRESSIVE || state == SummonStates.ATTACK)
            {
                state = SummonStates.PASSIVE;
                Debug.Log("Not Heal");
            }
            switch (state)
            {
                case SummonStates.FOLLOW:
                    agent.isStopped = false;
                    agent.speed = moveSpeed;
                    FollowState();
                    break;
                case SummonStates.PASSIVE:
                    agent.speed = moveSpeed;
                    PassiveState();
                    break;
                case SummonStates.WAIT:
                    agent.speed = moveSpeed;
                    Waiting();
                    break;
                case SummonStates.AGGRESSIVE:
                    agent.speed = moveSpeed;
                    agent.isStopped = false;
                    AgressiveState();
                    break;
                case SummonStates.ATTACK:
                    agent.speed = attackMoveSpeed;
                    agent.isStopped = false;
                    AttackState();
                    break;
                case SummonStates.HEAL:
                    agent.speed = moveSpeed;
                    agent.isStopped = false;
                    HealFire();
                    break;

            }
        }
    }
    void AttackSummonAiController() // attack summons will likely have taunts and so will healandAttack summons
    {
        //Going to be a button that turns the ai to either a passive state o
        if (!isStationary)
        {
            switch (state)
            {
                case SummonStates.FOLLOW:
                    agent.isStopped = false;
                    agent.speed = moveSpeed;
                    FollowState();
                    break;
                case SummonStates.PASSIVE:
                    agent.speed = moveSpeed;
                    PassiveState();
                    break;
                case SummonStates.WAIT:
                    agent.speed = moveSpeed;
                    Waiting();
                    break;
                case SummonStates.AGGRESSIVE:
                    agent.speed = moveSpeed;
                    agent.isStopped = false;
                    AgressiveState();
                    break;
                case SummonStates.ATTACK:
                    agent.speed = attackMoveSpeed;
                    agent.isStopped = false;
                    AttackState();
                    break;
            }
        }
        else if (isStationary)
        {
            switch (state)
            {
                case SummonStates.PASSIVE:
                    isAttacking = false;
                    agent.speed = moveSpeed;
                    PassiveState();
                    break;
                case SummonStates.WAIT:
                    isAttacking = false;
                    agent.speed = moveSpeed;
                    Waiting();
                    break;
                case SummonStates.AGGRESSIVE:
                    isAttacking = false;
                    agent.speed = moveSpeed;
                    AgressiveState();
                    break;
                case SummonStates.ATTACK:
                    agent.speed = attackMoveSpeed;
                    AttackState();
                    break;
                default:
                    CheckIfInEnemyIsInRange();
                    break;
            }
        }
    }

    void PassiveState() // Follows player and will only attack if the player does
    {
        if (isHealer) // Going to be follow state for healer
        {
            if (Vector3.Distance(transform.position, summoner.transform.position) > 5)
            {
                agent.destination = summoner.transform.position;
                agent.isStopped = false;
            }
            else
                agent.isStopped = true;
            return;
        }
        if (isStationary)
        {
            CheckIfInEnemyIsInRange();
        }
        else if (!isStationary)
        {
            if (Vector3.Distance(transform.position, summoner.transform.position) > 5)
            {
                agent.destination = summoner.transform.position;
                agent.isStopped = false;
            }
            else
                agent.isStopped = true;
            CheckIfInEnemyIsInRange();
        }

    }
    void AttackState() // Attacks enemey
    {
        if (lookAt != null)
        {

            //attack, probably will just shoot something rn
            if (!tele.isDone && !isAttacking)
            {
                tele.AttackRange(attackRange, attackProjector, 2, false);
                isAttacking = true;
            }
            if (tele.isDone && !isWaiting)
            {
                StartCoroutine(WaitForDelay());
            }
            if (!isStationary && lookAt != null)
            {
                agent.destination = lookAt.transform.position;
                float dist = Vector3.Distance(transform.position, lookAt.transform.position);
                if (dist < attackRangeFromEnemy)
                {
                    agent.isStopped = true;
                }
                else
                    agent.isStopped = false;
            }
            EnemyOutOfRange();

        }
        else if (lookAt != null && lookAt.GetComponent<EnemyInformation>().PlayerHealth < 0 || lookAt == null)
            CheckIfInEnemyIsInRange();
    }
    void EnemyOutOfRange() //Checks if the enemy is out of range
    {
        float dist = Vector3.Distance(transform.position, lookAt.transform.position);
        if (dist > attackRange * Scalar.rangeScalar)
        {
            attackProjector.SetActive(false);
            state = SummonStates.WAIT;
            isAttacking = false;
        }
    }
    void Fire() // Blast Ability
    {
        AbilityInformation ability = new AbilityInformation();
        ability.blast = new BlastAbilities();
        bulletInst = Instantiate(projectile, gameObject.transform.GetChild(0).transform.position, gameObject.transform.GetChild(0).transform.rotation);
        bulletInst.transform.position = gameObject.transform.GetChild(0).transform.position;
        bulletInst.GetComponent<Rigidbody>().velocity = bulletInst.transform.forward * 50;
        bulletInst.AddComponent<Damage>();
        bulletInst.AddComponent<AbiliyCont>();
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Summon");
        for (int i = 0; i < temp.Length; i++)
        {
            Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), temp[i].GetComponent<Collider>());
        }
        Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), summoner.GetComponent<Collider>());
        bulletInst.GetComponent<Damage>().SetDamage(((int)ability.blast.GetDamage(summon.BaseDamage, (int)GameInformation.CritChance)) / 5);// will change this number to a crit modifer * the scalar.
        if (isAttackHeals)
        {
            if (GameInformation.PlayerHealth + summon.HealAmount > GameInformation.PlayerMaxHp)
            {
                GameInformation.PlayerHealth = GameInformation.PlayerMaxHp;
            }
            else
            {
                float tempAmount = summon.HealAmount * Random.Range(0.95f, 0.98f);
                GameInformation.PlayerHealth += (int)tempAmount;
            }
        }
    }
    void HealFire() // Healing ability..but it is a blast
    {
        AbilityInformation ability = new AbilityInformation();
        ability.sustained = new SustainedAbilities();
        healInst = Instantiate(healprojectile, gameObject.transform.GetChild(0).transform.position, gameObject.transform.GetChild(0).transform.rotation);
        healInst.transform.position = gameObject.transform.GetChild(0).transform.position;
        healInst.GetComponent<Rigidbody>().velocity = healInst.transform.forward * 50;
        if (!healInst.GetComponent<Healing>())
            healInst.AddComponent<Healing>();
        healInst.AddComponent<AbiliyCont>();
        healInst.GetComponent<Healing>().SetHealing(((int)ability.sustained.GetHealing((int)(summon.CritChance))) / 5, this.gameObject);// will change this number to a crit modifer * the scalar.
    }
    void ChannelledAttack()
    {
        AbilityInformation ability = new AbilityInformation() { channelled = new ChannelledAbilities() };
        if (!channelledProj.activeInHierarchy)
        {
            // Going to be set from the suit so its not implemented yet
            channelledProj.SetActive(true);
            StartCoroutine(Duration(summon.ChannelledDuration, channelledProj));
        }

    }
    void AgressiveState() // Will attack enemies on sight
    {
        agent.destination = summoner.transform.position;
        float dist = Vector3.Distance(transform.position, summoner.transform.position);
        if (dist < 7f)
            agent.isStopped = true;
        else
            agent.isStopped = false;
        CheckIfInEnemyIsInRange();
    }
    void FollowState() // Follows player
    {
        agent.destination = summoner.transform.position;
        float dist = Vector3.Distance(transform.position, summoner.transform.position);
        if (dist < 7f)
            agent.isStopped = true;
        else
            agent.isStopped = false;
        CheckIfInEnemyIsInRange();
    }
    void HealTarget() // Going to heal player if below a certain amount
    {
        GetPercent();
        if (Vector3.Distance(transform.position, summoner.transform.position) > 15)
        {
            agent.destination = summoner.transform.position;
            agent.isStopped = false;
        }
        else
            agent.isStopped = true;
        if (percent < 90)
        {
            lookAt = summoner; // <- will look at the target and throw a heal spell its way

            if (lookAt != null)
            {

                //attack, probably will just shoot something rn
                if (!tele.isDone && !isAttacking)
                {
                    tele.AttackRange(attackRange, attackProjector, 2, false);
                    isAttacking = true;
                }
                if (tele.isDone && !isWaiting)
                {
                    StartCoroutine(WaitForDelay());
                }
                if (!isStationary && lookAt != null)
                {
                    agent.destination = lookAt.transform.position;
                    float dist = Vector3.Distance(transform.position, lookAt.transform.position);
                    if (dist < healRangeFromAlly)
                    {
                        agent.isStopped = true;
                    }
                    else
                        agent.isStopped = false;
                }
            }

        }
        // if the players health is lower then 50% or so heal the player then once it goes above, go back to attack mode.
        // Or maybe the player puts it in heal state

    }
    void Waiting()
    {
        if (isStationary)
        {
            // transform.RotateAround(Vector3.zero, Vector3.up, 360f * Time.deltaTime / 1f);
            CheckIfInEnemyIsInRange();
        }
        else
            agent.isStopped = true;
        CheckIfInEnemyIsInRange();
    }
    void CheckIfInEnemyIsInRange()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, attackRange * Scalar.rangeScalar);
        foreach (Collider temp in col)
        {
            if (temp.GetComponent<EnemyInformation>())
            {
                //look towards that target
                lookAt = temp.gameObject;
                state = SummonStates.ATTACK;
                return;
            }
        }
        Debug.Log("Found nothing");
        // state = SummonStates.WAIT;
    }
    IEnumerator WaitForDelay()
    {
        isWaiting = true;
        if (attackProjector.activeInHierarchy && state != SummonStates.HEAL)
            Fire();
        else if (state == SummonStates.HEAL)
            HealFire();
        yield return new WaitForSeconds(delayInterval);
        isAttacking = false;
        isWaiting = false;

    }
    IEnumerator Duration(int duration, GameObject channelledAbility)
    {
        yield return new WaitForSeconds(duration);
        channelledProj.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, attackRange * Scalar.rangeScalar);
    }
    public void ChangeStatesBasedOnButtons(string aiState)
    {
        if (aiState == "Agressive")
        {
            state = SummonStates.AGGRESSIVE;
        }
        if (aiState == "Wait")
        {
            state = SummonStates.WAIT;
        }
        if (aiState == "Passive")
        {
            state = SummonStates.PASSIVE;
        }
    }
}
