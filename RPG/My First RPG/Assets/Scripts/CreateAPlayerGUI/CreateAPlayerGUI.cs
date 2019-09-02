using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAPlayerGUI : MonoBehaviour {


    public enum CreateAPlayerStates
    {
        
        CLASSSELECTION, // DISPLAY ALL CLASS TYPES
        STATALLOCATION, // Choose your stats
        FINALSETUP,      // Finalize (name, gender, etc)
        INGAME          //InGame
    }
    private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions();
    public static CreateAPlayerStates currentState;
    public float widthHeighRatio;
	// Use this for initialization
	void Start () {
        currentState = CreateAPlayerStates.CLASSSELECTION;
	}
	
	// Update is called once per frame
	void Update () {
        widthHeighRatio = Screen.width / Screen.height;
        switch (currentState)
        {
            case (CreateAPlayerStates.CLASSSELECTION):
                break;
            case (CreateAPlayerStates.STATALLOCATION):
                break;
            case (CreateAPlayerStates.FINALSETUP):
                break;
            case (CreateAPlayerStates.INGAME):
                break;
            
        }

	}
   void OnGUI()
    {
            displayFunctions.DisplayMainItems();
        if (currentState == CreateAPlayerStates.CLASSSELECTION)
        {
            //Display Classes
            displayFunctions.DisplayClassSelections();
        }
        if (currentState == CreateAPlayerStates.STATALLOCATION)
        {
            //Display Stats
            displayFunctions.DisplayStatAllocation();
        }
        if (currentState == CreateAPlayerStates.FINALSETUP)
        {
            //Final Procces show gender, name, etc;
            //Debug.Log(GameInformation.Stamina);
            displayFunctions.DisaplyFinalSetUp();
        }
        if(currentState == CreateAPlayerStates.INGAME)
        {
            //Display UI in game
            Debug.Log("In Game");
            displayFunctions.DisplayInGame();

        }
    }
}
