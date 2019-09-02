using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {
// Partial classes can be added to in different structures and combine at the end
    public string[] quests;
    WWW questData;
    // Use this for initialization
    IEnumerator Start () {
         questData = new WWW("https://gregjohn.000webhostapp.com/QuestData.php");
        yield return questData;
        string questDataString = questData.text;
        print(questDataString);
        // NEW THIS SPLITS AT THE DEFINDED VALUE IN THERE REALLY COOL ACTUALLY
        quests = questDataString.Split(';');
        NPCInformation[] npcInformation = GameObject.FindObjectsOfType(typeof(NPCInformation)) as NPCInformation[];
        for (int i = 0; i < quests.Length-1; i++)
        {
            // This will grab all the data from the quest database and insert it into a list of quest
            // I can then grab info from this list of quest
            FetchQuest quest = new FetchQuest();
            quest.iD = int.Parse(GetDataValue(quests[i], "ID"));
            quest.questDescription = GetDataValue(quests[i], "QuestDescription");
            quest.questReward = GetDataValue(quests[i], "QuestReward");
            quest.objective = GetDataValue(quests[i], "Objective");
            quest.gold = int.Parse(GetDataValue(quests[i], "GoldReward"));
            quest.xp = int.Parse(GetDataValue(quests[i], "XPReward"));
            quest.prerequisite = int.Parse(GetDataValue(quests[i], "Prerequisites"));
            quest.objectiveName = GetDataValue(quests[i], "ObjectiveName");
            quest.requiredLevel = int.Parse(GetDataValue(quests[i], "RequiredLevel"));
            quest.questGiver = GetDataValue(quests[i], "QuestGiver");
            Quest.quest.Add(quest);
            for (int j = 0; j < npcInformation.Length; j++)
            {
                if(npcInformation[j].PlayerName == GetDataValue(quests[i], "QuestGiver"))
                {
                    // This is what i use to set the quest for the npcs
                    // The quest will be given to npcs depending on there name.
                    // Every npc will be given a list of quest that they can give and a quest counter to 
                    // advance players in a quest line.
                    // As of right now, quest givers only give 1 quest at a time. It is possible to make them able to give 
                    // more if needed
                    npcInformation[j].QuestIDs.Add(quest.iD);
                    BaseNpc npc = npcInformation[j].gameObject.GetComponent<BaseNpc>();
                    npc.iD = npcInformation[j].QuestIDs.ToArray();
                    npcInformation[j].interactions.questId = npcInformation[j].QuestIDs[npcInformation[j].QuestCounter]; 
                }
            }                 
        }
        

	}
    string GetDataValue(string data, string index)
    {
        
        
        
        string value = data.Substring(data.IndexOf(index) + index.Length+1);
        if(value.Contains("|"))
        value = value.Remove(value.IndexOf("|"));

        // Going to add each value for the database into a list

        FetchQuest quest = new FetchQuest();
        return value;
    }
}
