using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage: MonoBehaviour{
    int damage;
    FloatingText text;  
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
        
        //Debug.Log(damage);
    }
    public int GetDamage()
    {
        return damage;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<EnemyInformation>())
        {
            EnemyInformation enemy = collision.gameObject.GetComponent<EnemyInformation>();
            enemy.PlayerHealth -= damage;
            //Call PopupDamage Function.
            //Debug.Log("Hit Enemy");
            //text = GameObject.FindGameObjectWithTag("UiManager").GetComponent<FloatingText>();
            //text.DamageText(gameObject.transform.position, damage, collision.gameObject);
            GameObject temp = Instantiate(Resources.Load<GameObject>("FloatingText/TextPrefab"));
            temp.GetComponent<TextMesh>().text = damage.ToString();
            temp.transform.position = new Vector3(collision.transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y + 3.0f, collision.transform.position.z);
            Destroy(temp, 0.6f);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log(this.gameObject);
            GameInformation.PlayerHealth -= damage;
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Summon")
        {
            SummonInfo summon = collision.GetComponent<SummonsAi>().summon;
            summon.SummonHealth -= damage;
            Debug.Log(summon.SummonHealth);
            Destroy(this.gameObject);
        }
        //Destroy(this.gameObject);
    }
}
