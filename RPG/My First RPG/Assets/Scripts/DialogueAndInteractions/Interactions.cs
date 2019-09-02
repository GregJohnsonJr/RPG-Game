using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
// Quest npcs will have different text then normal ones
// Ever quest npc will be given a list of quest ids and a counter
// the counter will start at zero, and that will be for finding the correct quest id 
// The quest id is all in the name base, the quest ids are all added to an array depending on who the questgiver is, also in the database
// everytime you complete the quest the quest counter will increase, which will allow us acces to the next quest, we will then
// be able to find out if the player has the correct prerequists before the are able to go on the next quest.
// When it comes to save quest, make sure to use an _ so we can seperate it and grab the name of who we are saving
// I think this is an ok quest system? LETS GO!

public class Interactions : MonoBehaviour
{
    GameObject player;
    Text text;
    bool isDisplayed;
    [HideInInspector]
    public int questId;
    public GameObject questText;
    bool isWait = false;
    bool isAccepted;
    QuestList questList;
    [HideInInspector]
    public bool isNear;


    // Use this for initialization
    void Start()
    {
        questText.SetActive(false);
        isDisplayed = false;
        player = GameObject.FindGameObjectWithTag("Player");
        text = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Text>();
        isAccepted = false;
        questList = GameObject.FindGameObjectWithTag("UiManager").GetComponent<QuestList>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
         isNear = IsCharacterClose();
        if (isNear && Input.GetKeyDown(KeyCode.Z) && isAccepted && questText.activeInHierarchy == false)
        {
            isDisplayed = true;
            questText.SetActive(true);
            questText.GetComponentInChildren<Text>().text = "Hows that quest going?";
        }
        if (isDisplayed && Input.GetKeyDown(KeyCode.Z) && !isAccepted)
        {
            // Change the name to Enemy Information name <- found the looppole do in the morning
            FetchQuest quest = new FetchQuest();
           
            string temp = quest.GetObjective(questId); // I need a system to after certian levels the quest iD for the npc changes, or after certain prerequistes are meet.
            if (!quest.isQuestComplete && temp.Contains("Kill")) // Maybe if i make an array of quest iDs then make as system to where the quest id changes
            {                                                   // After the player completes a prerequistes, also make NPC information that stores all of 
                                                                // There quest...                
                                                                // Also i have to add all the quest to a active quest list for the player.
                EnemyInformation[] temporary = GameObject.FindObjectsOfType(typeof(EnemyInformation)) as EnemyInformation[];
                List<GameObject> enemysFound = new List<GameObject>();
                for (int i = 0; i < temporary.Length; i++)
                {
                    if (temporary[i].name == quest.GetObjectiveName(questId))
                    {
                        enemysFound.Add(temporary[i].gameObject);
                    }
                }
                GameObject[] temp2 = enemysFound.ToArray();
                KillQuest kill = gameObject.GetComponent<KillQuest>();
                // Learn Regex-> this is how you convert find numbers in a string and add it to the string then parse
                string result = Regex.Match(quest.GetObjective(questId), @"\d+").Value;
                int resultNum = int.Parse(result);
                kill.InitializeKillQuest(temp2, resultNum);
                GameObject tempQuestText = GameObject.FindGameObjectWithTag("QuestNotif");
                tempQuestText.GetComponent<Text>().text = "Quest Started!!";
                StartCoroutine(GetRidOfCompleteText());
            }
            else if (temp.Contains("Save"))
            {
                GameObject tempQuestText = GameObject.FindGameObjectWithTag("QuestNotif");
                tempQuestText.GetComponent<Text>().text = "Quest Started!!";
                StartCoroutine(GetRidOfCompleteText());
                SaveQuest saveQuest = gameObject.GetComponent<SaveQuest>();
                saveQuest.StartSaveQuest(quest.GetObjectiveName(questId), this.gameObject);
                
            }
            else if(temp.Contains("Find"))
            {
                GameObject tempQuestText = GameObject.FindGameObjectWithTag("QuestNotif");
                tempQuestText.GetComponent<Text>().text = "Quest Started!!";
                DropQuests drop = gameObject.GetComponent<DropQuests>();
                drop.ItemToFind(2, this.gameObject, 5);
            }
            FetchQuest tempQuest = new FetchQuest();
            tempQuest = (FetchQuest)Quest.quest[questId-1];
            GameInformation.activeQuest.Add(tempQuest);
            questList.AddToQuestLog();
            isAccepted = true;
        }
        if (isNear && Input.GetKeyDown(KeyCode.Z) && !isAccepted)
        {
            isDisplayed = true;
            questText.SetActive(true);
            FetchQuest quest = new FetchQuest();
            if (quest.GetRequriedLevel(questId) < GameInformation.PlayerLevel && quest.IsPlayerReady(questId))
            {
                questText.GetComponentInChildren<Text>().text = quest.GetDescription(questId) + "\n Press Z to accept quest";
                text.text = "";
            }
        }

    }

    public void CompletedQuest()
    {
        questList.DeleteFromQuestLog((FetchQuest)Quest.quest[questId-1]);
        FetchQuest quest = new FetchQuest();
        quest.CompleteQuest(questId);
        GameObject temp = GameObject.FindGameObjectWithTag("QuestNotif");
        temp.GetComponent<Text>().text = "Completed! " + "Reward: " + "Xp" + quest.GetXPReward(questId) + " Gold: " + quest.GetGoldReward(questId);
        NPCInformation npc = gameObject.GetComponent<NPCInformation>();
        quest = (FetchQuest)Quest.quest[questId - 1];
        GameInformation.activeQuest.Remove(quest);
        npc.QuestCounter++;
        questId = npc.QuestIDs[npc.QuestCounter];
        isDisplayed = false;
        isAccepted = false;
        StartCoroutine(GetRidOfCompleteText());
    }

    bool IsCharacterClose()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            //Checks if the other text is displayed then displays text
            if (!isDisplayed)
            {
                text.text = "Press Z to talk";
            }
            return true;
        }
        else
        {
            text.text = "";
            isDisplayed = false;
            questText.GetComponentInChildren<Text>().text = "";
            questText.SetActive(false);
            return false;
        }
    }
    IEnumerator GetRidOfCompleteText()
    {
        yield return new WaitForSeconds(3f);
        GameObject temp = GameObject.FindGameObjectWithTag("QuestNotif");
        temp.GetComponent<Text>().text = "";
    }
    IEnumerator Wait()
    {
        isWait = true;
        yield return new WaitForSeconds(3f);
        CompletedQuest();
        isWait = false;
    }
}
