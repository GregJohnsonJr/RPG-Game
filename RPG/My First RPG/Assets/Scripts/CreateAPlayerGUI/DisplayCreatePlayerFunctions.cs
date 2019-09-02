using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayCreatePlayerFunctions  {


    CreateAPlayerGUI create;
    private StatAllocationModule statAllocationModule = new StatAllocationModule();
    private int classSelection;
    private string[] classSelectionNames = new string[] { "Mage", "Warrior", "Archer", "Rouge", "Priest", "Warlock", "Paladin", "Enhancer" };
    private string playerName = "Enter Character Name"; // Name
    private string playerBio = "Enter Player Bio"; // bio
    private bool isMale = true;  //Gender
    private int genderSelection;
    private string[] genderTypes = new string[2] { "Male", "Female" };
  
    
    //Will stem into 1 advance class then into a choose of 3 other class(such as Elemental mage, Black Mage, etc);
    
    public void DisplayClassSelections()
    {
        // A list of toggle buttons and each button will be a different class
        //selection grid(time to learn)
        
        classSelection = GUI.SelectionGrid(new Rect(50,50,250,300), classSelection, classSelectionNames, 2);
        GUI.Label(new Rect(450, 50, 300, 300), FindClassDescription(classSelection));
        GUI.Label(new Rect(450, 100, 300, 300), FindClassStatValues(classSelection));
       

    }
    private string FindClassDescription(int classSelection)
    {
       if (classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseMageClass();
            return tempClass.CharacterClassDescrip;
        }
       else if (classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseWarriorClass();
            return tempClass.CharacterClassDescrip;
        }
        else if (classSelection == 2)
        {
            BaseCharacterClass tempClass = new BaseArcherClass();
            return tempClass.CharacterClassDescrip;
        }
        else if (classSelection == 3)
        {
            BaseCharacterClass tempClass = new BaseRougeClass();
            return tempClass.CharacterClassDescrip;
        }
        else if (classSelection == 4)
        {
            BaseCharacterClass tempClass = new BasePriestClass();
            return tempClass.CharacterClassDescrip;
        }
        else if (classSelection == 5)
        {
            BaseCharacterClass tempClass = new BaseWarlockClass();
            return tempClass.CharacterClassDescrip;
        }
        else if (classSelection == 6)
        {
            BaseCharacterClass tempClass = new BasePaladinClass();
            return tempClass.CharacterClassDescrip;
        }
        else if (classSelection == 7)
        {
            BaseCharacterClass tempClass = new BaseEnhancerClass();
            return tempClass.CharacterClassDescrip;
        }
        return "No Class Found";
    }

    private string FindClassStatValues(int classSelection)
    {
        if(classSelection == 0)
        {
            BaseCharacterClass tempClass = new BaseMageClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 1)
        {
            BaseCharacterClass tempClass = new BaseWarriorClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 2)
        {
            BaseCharacterClass tempClass = new BaseArcherClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 3)
        {
            BaseCharacterClass tempClass = new BaseRougeClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 4)
        {
            BaseCharacterClass tempClass = new BasePriestClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 5)
        {
            BaseCharacterClass tempClass = new BaseWarlockClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 6)
        {
            BaseCharacterClass tempClass = new BasePaladinClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
        else if (classSelection == 7)
        {
            BaseCharacterClass tempClass = new BaseEnhancerClass();
            string tempStats = "Stamina " + tempClass.Stamina + "\n" + "Endurance " + tempClass.Endurance + "\n" + "Intellect " + tempClass.Intellect + "\n" + "Strength " + tempClass.Strength + "\n" + "Agility " + tempClass.Agility + "\n" + "Resistance " + tempClass.Resistance + "\n" + "Mastery " + tempClass.Mastery; // Finish it off add all classes
            return tempStats;
        }
      
        return "No Stats Found";

    }

    public void DisplayStatAllocation()
    {
        //A list of stats with plus and minus buttons to start off. Lets player choose.
        //Use logic so player cannot add or minus more than given
        statAllocationModule.DisplayStatAllocationModule();
    }

    public void DisaplyFinalSetUp()
    {
        //name
        playerName = GUI.TextArea(new Rect(20, 10, 150, 25), playerName, 25);

        //gender
        genderSelection = GUI.SelectionGrid(new Rect(200, 10, 100, 75), genderSelection, genderTypes, 1);
        //add a description to character bio maybs
        playerBio = GUI.TextArea(new Rect(20, 90, 250, 200), playerBio, 250);
      
    }
    public void DisplayInGame()
    {
        // can probs use for ui actually

    }

    private void ChooseClass(int classSelection)
    {
        if (classSelection == 0)
        {
            GameInformation.PlayerClass = new BaseMageClass();
        }
        else if (classSelection == 1)
        {
            GameInformation.PlayerClass = new BaseWarriorClass();
        }
        else if (classSelection == 2)
        {
            GameInformation.PlayerClass = new BaseArcherClass();

        }
        else if (classSelection == 3)
        {
            GameInformation.PlayerClass = new BaseRougeClass();

        }
        else if (classSelection == 4)
        {
            GameInformation.PlayerClass = new BasePriestClass();

        }
        else if (classSelection == 5)
        {
            GameInformation.PlayerClass = new BaseWarlockClass();
        }
        else if (classSelection == 6)
        {
            GameInformation.PlayerClass = new BasePaladinClass();

        }
        else if (classSelection == 7)
        {
            GameInformation.PlayerClass = new BaseEnhancerClass();

        }
    }

    // Time.delta time to make it move by seconds
    public static bool isRight = false, isLeft = false;
    public void DisplayMainItems()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GUI.Label(new Rect(Screen.width /2, 20, 250, 250), "CREATE NEW PLAYER");

        
        if(CreateAPlayerGUI.currentState != CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP) // if wea re not in the final setup then show the next button
        {
            if (GUI.Button(new Rect(Screen.width/1.55f, 310, 50, 50), "Next"))
            {
                if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION)
                {
                    ChooseClass(classSelection);
                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
                else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    GameInformation.Stamina = StatAllocationModule.pointsToAllocate[0];
                    GameInformation.Endurance  = StatAllocationModule.pointsToAllocate[0];
                    GameInformation.Intellect = StatAllocationModule.pointsToAllocate[0];
                    GameInformation.Strength = StatAllocationModule.pointsToAllocate[0];
                    GameInformation.Agility = StatAllocationModule.pointsToAllocate[0];
                    GameInformation.Resistance = StatAllocationModule.pointsToAllocate[0];
                    GameInformation.Mastery = StatAllocationModule.pointsToAllocate[0];
                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP;
                }
            }
        }
        else if(CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP)
        {
            bool isClicked = false;
            if( GUI.Button(new Rect(850, 310, 50, 50), "Finish"))
            {
                //FINAL SAVE
                GameInformation.PlayerName = playerName;
                GameInformation.PlayerBio = playerBio;
                if (genderSelection == 0)
                    GameInformation.IsMale = true;
                else if (genderSelection == 1)
                    GameInformation.IsMale = false;
                SaveInformation.SaveAllInformation();
                Debug.Log("Make Final Save");
                isClicked = true;
                CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.INGAME;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CreateAPlayerGUI>().enabled = false;
                SceneManager.LoadScene(1);
                //create.enabled = !create.enabled;
            }
           
        }
        if (CreateAPlayerGUI.currentState != CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION)
        {
            if (GUI.Button(new Rect(550, 310, 50, 50), "Back"))
            {
                if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION)
                {
                    
                    statAllocationModule.didRunOnce = false;
                    statAllocationModule.availPoints = 5;
                   // Debug.Log(GameInformation.PlayerClass.CharacterClassName);             
                   
                   

                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.CLASSSELECTION;
                }
                else if (CreateAPlayerGUI.currentState == CreateAPlayerGUI.CreateAPlayerStates.FINALSETUP)
                {
                    CreateAPlayerGUI.currentState = CreateAPlayerGUI.CreateAPlayerStates.STATALLOCATION;
                }
            }
        }
       



    }
    
}
