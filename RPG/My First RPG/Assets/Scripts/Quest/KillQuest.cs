using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillQuest : MonoBehaviour
{
    // Update is called once per frame
    [HideInInspector]
    public bool isMonster;
    int maxAmount;
    int amountToKill;
    GameObject monsterToKill;
    [HideInInspector]
    public EnemyInformation enemy;
    Interactions interactions;
    [HideInInspector]
    public GameObject holder;
    public bool isReady;
    bool isCompleted;
    void Update()
    {

        if (isReady)
        {
            if (!enemy && this.gameObject.tag == "Snail")
            {
                enemy = gameObject.GetComponent<EnemyInformation>();
            }

            /*if (this.gameObject.tag == "Snail" && enemy.PlayerHealth < 0 && !hasDied) <- this happends in enemy Information
            {
                CheckIfMonsterDied();
                hasDied = true;
               // Destroy(this.gameObject);
            }*/
        }
        if (amountToKill > 0 && holder == this.gameObject && holder.GetComponent<KillQuest>().amountToKill == holder.GetComponent<KillQuest>().maxAmount && !isCompleted)
        {
            holder.GetComponent<Interactions>().CompletedQuest();
            isCompleted = true;
        }

    }
    
    /// <summary>
    /// This function works by an array of monsters and a amount
    /// The array of monsters is dynamicly created by finding enemyInformation on all objects and adding it to all enemys with that name. I will probably add
    /// it to the spawn of the monsters once the quest is Created
    /// </summary>
    /// <param name="monster"></param>
    /// <param name="amount"></param>
    public void InitializeKillQuest(GameObject[] monster, int amount)
    {
        // Have to add a wait method just incase it does not find the monster.
        maxAmount = amount;
        if(monster.Length > 0)
        monsterToKill = monster[0];
        GameObject[] temp = monster;
        holder = this.gameObject;
        isCompleted = false;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] == this.gameObject)
            {
                continue;
            }
            temp[i].AddComponent<KillQuest>();
            temp[i].GetComponent<KillQuest>().isMonster = true;
            temp[i].GetComponent<KillQuest>().enemy = gameObject.GetComponent<EnemyInformation>();
            temp[i].GetComponent<KillQuest>().holder = this.gameObject;
            temp[i].GetComponent<KillQuest>().isReady = true;      
        }     
    }
    public void CheckIfMonsterDied()
    {
        if (isMonster)
        {
            enemy = gameObject.GetComponent<EnemyInformation>();    
            if (enemy.PlayerHealth < 0 && !(holder.GetComponent<KillQuest>().amountToKill >= holder.GetComponent<KillQuest>().maxAmount))
            {
                
                holder.GetComponent<KillQuest>().amountToKill += 1;
                GameObject temp = GameObject.FindGameObjectWithTag("QuestNotif");
                temp.GetComponent<Text>().text = holder.GetComponent<KillQuest>().amountToKill + " / " + holder.GetComponent<KillQuest>().maxAmount + " Left";
            }
        }
    }
}
