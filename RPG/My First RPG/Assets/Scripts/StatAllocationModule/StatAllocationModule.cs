using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAllocationModule  {

    private string[] statNames = new string[7] { "Stamina", "Endurance", "Intellect", "Strength", "Agility", "Resistance", "Mastery" };
    private string[] statDescriptions = new string[7] { "Energy modifer", "Health modifer", "Magical damage modifer", "Physical damage modifer", "Speed and Crit modifer", "Damage Reduction", "Special move modifer" };
    private bool[] statSelections = new bool[7];
    public static int[] pointsToAllocate = new int[7]; // we will start 5 per level per class, 
    private int[] baseStatPoints = new int[7]; // starting values (79 stats)

    public int availPoints = 5;
    public bool didRunOnce = false;


    public void DisplayStatAllocationModule()
    {
        if (!didRunOnce)
        {
            RetrieveStatBaseStatPoints();
            didRunOnce = true;
        }
        DisplayStatToggleSwitches();
        DisplayStatIncreaseDecreaseButtons();


    }

    private void DisplayStatToggleSwitches()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statSelections[i] = GUI.Toggle(new Rect(10, 55 * i + 10, 100, 50), statSelections[i], statNames[i]);
            GUI.Label(new Rect(100, 55 * i + 10, 50, 50), pointsToAllocate[i].ToString());
            if (statSelections[i])
                GUI.Label(new Rect(20, 55 * i + 30, 150, 100), statDescriptions[i]);

        }//Creating the rest tommorrow GL soldier
    }
    


    private void DisplayStatIncreaseDecreaseButtons()
    {
        for (int i = 0; i < pointsToAllocate.Length; i++) 
        {
            if (pointsToAllocate[i] >= baseStatPoints[i] && availPoints > 0)
            {

                if (GUI.Button(new Rect(200, 55 * i + 10, 50, 50), "+"))
                {
                    pointsToAllocate[i] += 1;
                    --availPoints;

                }
            }

            if (pointsToAllocate[i] > baseStatPoints[i])
            {
                if (GUI.Button(new Rect(260, 55 * i + 10, 50, 50), "-"))
                {
                    pointsToAllocate[i] -= 1;
                    ++availPoints;
                }
            }
        }
    }

    private void RetrieveStatBaseStatPoints()
    {
        BaseCharacterClass cClass = GameInformation.PlayerClass;
        pointsToAllocate[0] = cClass.Stamina;
        baseStatPoints[0] = cClass.Stamina;
        pointsToAllocate[1] = cClass.Endurance;
        baseStatPoints[1] = cClass.Endurance;
        pointsToAllocate[2] = cClass.Intellect;
        baseStatPoints[2] = cClass.Intellect;
        pointsToAllocate[3] = cClass.Strength;
        baseStatPoints[3] = cClass.Strength;
        pointsToAllocate[4] = cClass.Agility;
        baseStatPoints[4] = cClass.Agility;
        pointsToAllocate[5] = cClass.Resistance;
        baseStatPoints[5] = cClass.Resistance;
        pointsToAllocate[6] = cClass.Mastery;
        baseStatPoints[6] = cClass.Mastery;



    }

}
