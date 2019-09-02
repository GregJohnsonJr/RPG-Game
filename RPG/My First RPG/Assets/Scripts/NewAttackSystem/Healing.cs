using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour {
    int heal;
    int maxHp;
    FloatingText text;
    GameObject user;
    public void SetHealing(int healAmount, GameObject userOfAbility) //<- i have to add a maxhp value to enemyinfo
    {
        heal = healAmount;
        user = userOfAbility;
        //Debug.Log(damage);
    }
    private void OnTriggerEnter(Collider collision)
    {
        // <- gotta check for max hp
        if (collision.gameObject.GetComponent<EnemyInformation>() && user.GetComponent<EnemyInformation>())
        {
            EnemyInformation enemy = collision.gameObject.GetComponent<EnemyInformation>();
            if (enemy.PlayerHealth + heal > enemy.PlayerMaxHealth)
                enemy.PlayerHealth = enemy.PlayerMaxHealth;
            else
                enemy.PlayerHealth += heal;
            text = GameObject.FindGameObjectWithTag("UiManager").GetComponent<FloatingText>();
            text.DamageText(gameObject.transform.position, heal, collision.gameObject,Color.green);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log(this.gameObject);
            if (GameInformation.PlayerHealth + heal > GameInformation.PlayerMaxHp)
            {
                GameInformation.PlayerHealth = GameInformation.PlayerMaxHp;
            }
            else
                GameInformation.PlayerHealth += heal;
            Debug.Log("Healed: " + heal);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Summon")
        {
            SummonInfo summon = collision.GetComponent<SummonsAi>().summon;
            if (summon.SummonHealth + heal > summon.SummonMaxHealth )
            {
                summon.SummonHealth = summon.SummonMaxHealth;
            }
            else 
                summon.SummonHealth += heal;
            if(summon.SummonHealth > summon.SummonMaxHealth)
            {
                summon.SummonHealth = summon.SummonMaxHealth;
            }
            text = GameObject.FindGameObjectWithTag("UiManager").GetComponent<FloatingText>();
            text.DamageText(gameObject.transform.position, heal, collision.gameObject, Color.green);
            Debug.Log(summon.SummonHealth);
            Destroy(this.gameObject);
        }
        //Destroy(this.gameObject);
    }
}
