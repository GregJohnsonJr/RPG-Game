using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseNpc : MonoBehaviour {
    [HideInInspector]
    public int[] iD;
    NPCInformation npcInformation;
    void Awake () {
        if(iD.Length > 0)
        IntializeNpcQuest();
        IntializeNpcStats();

    }
    public void IntializeNpcQuest()
    {
        System.Array.Sort(iD);
        npcInformation = gameObject.GetComponent<NPCInformation>();
        for (int i = 0; i < iD.Length; i++)
        {
            npcInformation.QuestIDs[i] = iD[i];
        }
       
    }
    void IntializeNpcStats()
    {

    }
}
