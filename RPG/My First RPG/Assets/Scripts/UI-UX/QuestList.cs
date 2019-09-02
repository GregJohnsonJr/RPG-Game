using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    public Text quest;
    List<Text> texts = new List<Text>();
    // Update is called once per frame
    public void AddToQuestLog()
    {
        if (GameInformation.activeQuest.Count > 0)
        {
            for (int i = 0; i < GameInformation.activeQuest.Count; i++)
            {
                texts.Add(Instantiate(quest));
                texts[i].text = GameInformation.activeQuest[i].objective;
                texts[i].transform.SetParent(quest.transform.parent);
            }
        }
    }
    public void DeleteFromQuestLog(FetchQuest quest)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            if(texts[i].text == quest.objective)
            {
                Destroy(texts[i].gameObject);
                texts.RemoveAt(i);
            }
        }
    }
}
