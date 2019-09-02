using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour {
    int gold;
    int itemId;
    int enemyLevel;
    InvetoryR inventory;
    public GameObject dropInventory;
    bool isLootGenerated;
    int random;
    // Use this for in itialization
    void Start () {
        gold = Random.Range(5 * enemyLevel, 20 * enemyLevel);
        itemId = 2;
       inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InvetoryR>();
        isLootGenerated = false;
        random = Random.Range(1, 10);
        //Debug.Log(random);

    }
    public void SetEnemyLevel(int level)
    {
        enemyLevel = level;
    }
    private void OnMouseDown()
    {
        if (!isLootGenerated)
        {
            float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
            if (dist < 25)
            {
                
                Collider[] temp = Physics.OverlapSphere(transform.position, 20);
                foreach(Collider col in temp)
                {
                    if(col.GetComponent<EnemyDrops>() && col != this.GetComponent<Collider>())
                    {
                        random += col.GetComponent<EnemyDrops>().random;
                        Destroy(col.gameObject);
                    }                    
                }
  
                
                inventory.AddItemForDrops(2, random, this.gameObject);
                isLootGenerated = true;
            }
        }
        else if(isLootGenerated)
        {
            dropInventory.SetActive(true);
        }
        
    }
    private void Update()
    {
        if (isLootGenerated)
        {
            float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
            if (dist > 25)
            {
                dropInventory.SetActive(false);
            }
            if(!dropInventory)
            {
                Destroy(this.gameObject);
            }
        }
    }


}
