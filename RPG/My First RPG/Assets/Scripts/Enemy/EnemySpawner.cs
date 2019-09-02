using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {
    public GameObject monsterType;
    public float respawnTime;
    public int amount;
    private List<GameObject> monsters;
    bool isRespawning;
    public float distance;
    Interactions interactions;
    // Update is called once per frame
    private void Start()
    {
       
        isRespawning = false;
        monsters = new List<GameObject>();
        while (monsters.Count < amount)
        {
            GameObject temp = (Instantiate(monsterType));
            temp.name = monsterType.name;
            if(temp.name == "RSnail") // Only time I will hardcode this. I will change it in the future
            {
                temp.name = "Snail";
            }
            NavMeshHit hit;
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-distance, distance), transform.position.y + 3f, transform.position.z + Random.Range(-distance, distance));
            NavMesh.SamplePosition(pos, out hit, pos.magnitude, 1);
            Vector3 finalPos = hit.position;
            temp.GetComponent<NavMeshAgent>().Warp(finalPos);
            CheckForQuest(temp);
            monsters.Add(temp);
        }
    }
    void Update()
    {
        //Delete New Game Objects
       
        if (monsters.Count < amount && !isRespawning)
        {
            StartCoroutine(MonsterRespawn());
        }
        CheckIfMonstersInListAreNull();
    }
    void CheckIfMonstersInListAreNull()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            if(monsters[i] == null)
            {
                monsters.RemoveAt(i);
            }
        }
    }
    void CheckForQuest(GameObject temp)
    {
        for (int i = 0; i < GameInformation.activeQuest.Count; i++)
        {
            if(GameInformation.activeQuest[i].objectiveName == temp.name)
            {
                temp.AddComponent<KillQuest>();
                temp.GetComponent<KillQuest>().isMonster = true;
                temp.GetComponent<KillQuest>().enemy = temp.GetComponent<EnemyInformation>();
                temp.GetComponent<KillQuest>().isReady = true;
                temp.GetComponent<KillQuest>().holder = GameObject.Find(GameInformation.activeQuest[i].questGiver);
            }
        }
    }
    IEnumerator MonsterRespawn()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnTime);
        GameObject temp = (Instantiate(monsterType));
        temp.name = monsterType.name;
        if (temp.name == "RSnail") // Only time I will hardcode this. I will change it in the future
        {
            temp.name = "Snail";
        }
        NavMeshHit hit;
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-distance, distance), transform.position.y + 3f, transform.position.z + Random.Range(-distance, distance));
        NavMesh.SamplePosition(pos, out hit, pos.magnitude, 1);
        Vector3 finalPos = hit.position;
        temp.GetComponent<NavMeshAgent>().Warp(finalPos);
        CheckForQuest(temp);
        monsters.Remove(null);
        monsters.Add(temp);
        isRespawning = false;
    }
}
