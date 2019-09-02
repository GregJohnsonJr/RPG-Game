using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveQuest : MonoBehaviour {
    GameObject player;
    GameObject questController;
    string savedCharacter;
    
    // Update is called once per frame
    private void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update () {

        if (gameObject.name == savedCharacter)
        {
            bool isNear = CheckIfPlayerIsClose();
            if (isNear && Input.GetKey(KeyCode.Z))
            {
                // 
                questController.GetComponent<Interactions>().CompletedQuest();
                Destroy(gameObject.GetComponent<SaveQuest>());
            }
        }
	}
    bool CheckIfPlayerIsClose()
    {
        float dist = Mathf.Abs(Mathf.Abs(player.transform.position.sqrMagnitude) - Mathf.Abs(transform.position.sqrMagnitude));
        if(dist < 50)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Gave me the name so I can return the game object
    /// Give me the gameObject controller so i have the npc that gave the quest
    /// </summary>
    /// <param name="name"></param>
    public void StartSaveQuest(string name, GameObject questNPC)
    {
        GameObject temp =  NPCInformation.ReturnNPCGameObject(name);
        temp.AddComponent<SaveQuest>();
        questController = questNPC;
        savedCharacter = name;
        temp.GetComponent<SaveQuest>().savedCharacter = name;
        temp.GetComponent<SaveQuest>().questController = this.gameObject;
    }
}
