using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StateChange : MonoBehaviour , IPointerClickHandler {
    Button button;
    List<GameObject> ai;
	void Start()
    {
        button = gameObject.GetComponent<Button>();
        ai = new List<GameObject>();
    }
	void Update () {
        if(ai.Count < 2)
        LookForEnemyAis();
	}
    void LookForEnemyAis()
    {
        if (GameObject.FindGameObjectWithTag("Summon"))
        {
            var temp = GameObject.FindGameObjectsWithTag("Summon");
           
                for (int i = 0; i < temp.Length; i++)
                {
                if(!ai.Contains(temp[i]))
                    ai.Add(temp[i]);
                }
           
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < ai.Count; i++)
        {
            if (ai[i].GetComponent<SummonsAi>())
            {
                string temp = button.GetComponentInChildren<Text>().text;               
                ai[i].GetComponent<SummonsAi>().ChangeStatesBasedOnButtons(temp);
            }
        }
    }
}
