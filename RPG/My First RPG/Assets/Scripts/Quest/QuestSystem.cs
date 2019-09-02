using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest {
    public static List<Quest> quest;
    public abstract string GetQuestRewards(int iD);
    public abstract string GetDescription(int iD);
    public abstract string GetObjective(int iD);
    public abstract int GetGoldReward(int iD);
    public abstract int GetXPReward(int iD);
    public abstract int GetPrerequisites(int iD);
    public abstract void CompleteQuest(int iD);
    public abstract string GetObjectiveName(int iD);
    public abstract bool IsQuestComplete(int iD);
    public abstract bool IsPlayerReady(int iD);
    public abstract int GetRequriedLevel(int iD);
    public abstract string GetQuestGiver(int iD);

    //Prerequistes and id

}
public class FetchQuest : Quest
{
    public string questReward;
    public string questDescription;
    public int prerequisite;
    public int gold;
    public int xp;
    public int iD;
    public string objective;
    public string objectiveName;
    public bool isQuestComplete;
    public bool canCharacterDoQuest;
    public int requiredLevel;
    public string questGiver;
    public FetchQuest()
    {
        if (quest == null)
            quest = new List<Quest>();
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override string GetQuestRewards(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.questReward;
    }
    //Send the iD of the completed Quest
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override void CompleteQuest(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        fetchQuest.isQuestComplete = true;
        GameInformation.CurrentXp += GetXPReward(iD);
        if(GameInformation.CurrentXp > GameInformation.RequiredXP)
        {
            LevelUp level = new LevelUp();
            level.LevelUpCharacter();
        }
        GameInformation.Gold += GetGoldReward(iD);
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override string GetDescription(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.questDescription;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override string GetObjective(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.objective;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override int GetGoldReward(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.gold;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override int GetXPReward(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.xp;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override int GetPrerequisites(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.prerequisite;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override string GetObjectiveName(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.objectiveName;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override bool IsQuestComplete(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.isQuestComplete;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override bool IsPlayerReady(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        int pre = fetchQuest.prerequisite;
        if (pre == 0)
        {
            return true;
        }
        else if (IsQuestComplete(pre))
        {
            return true;
        }        
        return false;
    }
    /// <summary>
    ///ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override int GetRequriedLevel(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.requiredLevel;
    }
    /// <summary>
    /// ID has to be 1 or greater 
    /// </summary>
    /// <param name="iD"></param>
    /// <returns></returns>
    public override string GetQuestGiver(int iD)
    {
        FetchQuest fetchQuest = new FetchQuest();
        fetchQuest = (FetchQuest)quest[iD - 1];
        return fetchQuest.questGiver;
    }
    // Going to dynically change the quest id after you complete a quest
    // Right after you complete it i will add a counter going up in the quest id thing so we know how many quest are left in your sequence
}

