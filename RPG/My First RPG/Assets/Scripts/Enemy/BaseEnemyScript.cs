using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyScript : MonoBehaviour {


    int hp;
    int mana;
    BasePlayer newEnemy;
	int stamina;
	int intellect;
	int strength;
	int endurance;
    int resistance;
    int mastery;
    int agility;
    string name;
    bool calculated;
    bool init = false;
    KillQuest kill;
    StatCalculations calculations;
    EnemyInformation enemyInfo;
    public GameObject dropPouch;
    bool isDying = true;
    void Start()
    {         
        CalculateEnemyInfo(1);
    }
    /// <summary>
    /// 1 is mage, 2 is warrior, 3 is Enhancer, 4 is paladin, 5 is Priest, and 6 is archer
    /// </summary>
    /// <param name="enemyClassNum"></param>
    /// 
     void CalculateEnemyInfo (int enemyClassNum) {
        enemyInfo = gameObject.GetComponent<EnemyInformation>();
        newEnemy = new BasePlayer();
        calculations = new StatCalculations();
        name = gameObject.name;
        int number = enemyClassNum;
        if (number == 1)
        {
            enemyInfo.PlayerClass = new BaseMageClass();
            enemyInfo.MainStat = enemyInfo.Intellect;
        }
        else if (number == 2)
        {
            enemyInfo.PlayerClass = new BaseWarriorClass();
            enemyInfo.MainStat = enemyInfo.Strength;
        }
        else if (number == 3)
        {
            enemyInfo.PlayerClass = new BaseEnhancerClass();
            enemyInfo.MainStat = enemyInfo.Agility;
        }
        else if (number == 4)
        {
            enemyInfo.PlayerClass = new BasePaladinClass();
            enemyInfo.MainStat = enemyInfo.Endurance;
        }
        else if (number == 5)
        {
            enemyInfo.PlayerClass = new BasePriestClass();
            enemyInfo.MainStat = enemyInfo.Mastery;
        }
        else if (number == 6)
        {
            enemyInfo.PlayerClass = new BaseArcherClass();
            enemyInfo.MainStat = enemyInfo.Agility;
        }
        //MAKE SURE TO CREATE A NEW INSTANCE OF THIS FOR EVERY ENEMY/BOSS ETC.
        // HAve to add it to all the enemies in and playtest it
        // We are going to learn about networking soon.       
        enemyInfo.PlayerLevel = 20; // <- Dynamically from enemy scripts
        stamina = enemyInfo.PlayerClass.Stamina * (enemyInfo.PlayerLevel/2);
        intellect = enemyInfo.PlayerClass.Intellect * (enemyInfo.PlayerLevel / 2);
        strength = enemyInfo.PlayerClass.Strength * (enemyInfo.PlayerLevel / 2);
        endurance = enemyInfo.PlayerClass.Endurance * (enemyInfo.PlayerLevel / 2);
        agility = enemyInfo.PlayerClass.Agility * (enemyInfo.PlayerLevel / 2);
        mastery = enemyInfo.PlayerClass.Mastery * (enemyInfo.PlayerLevel / 2);
        resistance = enemyInfo.PlayerClass.Resistance;
        SetEnemyInfo();
        if (number == 1)
        {
            
            enemyInfo.MainStat = enemyInfo.Intellect;
        }
        else if (number == 2)
        {
            
            enemyInfo.MainStat = enemyInfo.Strength;
        }
        else if (number == 3)
        {
            
            enemyInfo.MainStat = enemyInfo.Agility;
        }
        else if (number == 4)
        {
            
            enemyInfo.MainStat = enemyInfo.Endurance;
        }
        else if (number == 5)
        {
           
            enemyInfo.MainStat = enemyInfo.Mastery;
        }
        else if (number == 6)
        {
            
            enemyInfo.MainStat = enemyInfo.Agility;
        }
        
        enemyInfo.PlayerMaxHealth = calculations.CalculateHealth(enemyInfo.Endurance);
        enemyInfo.PlayerMaxEnergy = calculations.CalculateEnergy(enemyInfo.Intellect);
        enemyInfo.PlayerHealth = enemyInfo.PlayerMaxHealth;
        enemyInfo.PlayerEnergy = enemyInfo.PlayerMaxEnergy;

        calculated = true;
        Debug.Log(calculated);
    }
	
	// Update is called once per frame
	void Update () {
        
		if(enemyInfo && enemyInfo.PlayerHealth <= 0 && isDying)
        {
            // Just to check for kill quest
            if (gameObject.GetComponent<KillQuest>())
            {
                kill = gameObject.GetComponent<KillQuest>();
                kill.CheckIfMonsterDied();
            }
            if (GameObject.Find("New Game Object"))
            {
                Destroy(GameObject.Find("New Game Object"));
            }
            if (GameObject.Find("New Game Object(Clone)"))
            {
                Destroy(GameObject.Find("New Game Object(Clone)"));
            }
            StartCoroutine(KillDelay());         
            GameInformation.CurrentXp += 20 * enemyInfo.PlayerLevel;
        }
	}
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {


            hp -= SwordSwingRT.damage;
            //Debug.Log(hp);
        }
    }
    void SetEnemyInfo()
    {
        enemyInfo.Stamina = stamina;
        enemyInfo.Intellect = intellect;
        enemyInfo.Endurance = endurance;
        enemyInfo.Strength = strength;
        enemyInfo.Resistance = resistance;
        enemyInfo.Agility = agility;
        enemyInfo.Mastery = mastery;
        enemyInfo.PlayerName = name;



    }
    void SetEnemyDrops()
    {
        GameObject temp = Instantiate(dropPouch);
        temp.transform.position = gameObject.transform.localPosition;
        temp.GetComponent<EnemyDrops>().SetEnemyLevel(enemyInfo.PlayerLevel);
    }
    IEnumerator KillDelay()
    {
        isDying = false;
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.yellow);
        gameObject.GetComponent<Collider>().enabled = false;
        if (gameObject.GetComponent<BaseEnemyAi>())
        {
            gameObject.GetComponent<BaseEnemyAi>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        if(gameObject.GetComponentInChildren<Projector>() && gameObject.GetComponentInChildren<Projector>().enabled)
        {
            gameObject.GetComponentInChildren<Projector>().enabled = false;
        }
        yield return new WaitForSeconds(2f);
        SetEnemyDrops();
        Destroy(gameObject);       
    }

}
