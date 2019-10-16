using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatAllocationRevamp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isPlus;
    public int statNum;
    private string[] statNames = new string[7] { "Stamina", "Endurance", "Intellect", "Strength", "Agility", "Resistance", "Mastery" };
    private string[] statDescriptions = new string[7] { "Energy modifer", "Health modifer", "Magical damage modifer", "Physical damage modifer", "Speed and Crit modifer", "Damage Reduction", "Special move modifer" };
    public Text descText;
    public float dist = 1f;
    bool isDisplayed;
    static int pointsToDistrubute = 5;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isPlus)
        {
            descText.gameObject.SetActive(true);
            isDisplayed = true;
            descText.text = statDescriptions[statNum];
            var screenPoint = Input.mousePosition;
            screenPoint.z = 0f; //distance of the plane from the camera
            descText.gameObject.transform.position = eventData.position;
            float distance = Vector3.Distance(descText.transform.position, transform.position);
            if (distance > dist)
            {
                float x = descText.transform.position.x;
                float dif = x - distance; // the difference between, how far away it is
                descText.transform.position = new Vector3(descText.transform.position.x + dif, descText.transform.position.y);
                Debug.Log("Too far: " + distance + "  Pos1: " + descText.transform.position + "Pos2:  " + transform.position+ " : " + dif);
            }
            Debug.Log("made it");
            
        }
    }
   
    public void OnPointerExit(PointerEventData eventData)
    {
        if(isDisplayed)
        {
            descText.gameObject.SetActive(false);
            Debug.Log("left");
            isDisplayed = false;
            descText.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        descText = Instantiate(descText);
        descText.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SetDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        isDisplayed = true;
    }
    public void hasClicked()
    {
        if (pointsToDistrubute > 0)
        {
          //  Debug.Log(statNum);
            if (statNum == 0)
            {
                GameInformation.Stamina += 1;
               // Debug.Log(GameInformation.Stamina);
            }
            else if (statNum == 1)
            {
                GameInformation.Endurance += 1;
              //  Debug.Log(GameInformation.Endurance);
            }
            else if (statNum == 2)
            {
                GameInformation.Intellect += 1;
              //  Debug.Log(GameInformation.Intellect);
            }
            else if (statNum == 3)
            {
                GameInformation.Strength += 1;
               // Debug.Log(GameInformation.Strength);
            }
            else if (statNum == 4)
            {
                GameInformation.Agility += 1;
                //Debug.Log(GameInformation.Agility);
            }
            else if (statNum == 5)
            {
                GameInformation.Resistance += 1;
                //Debug.Log(GameInformation.Resistance);
            }
            else if (statNum == 6)
            {
                GameInformation.Mastery += 1;
                //Debug.Log(GameInformation.Mastery);
            }
            pointsToDistrubute--;
           // Debug.Log(pointsToDistrubute);
        }
        else
            Debug.Log("Out of points");
    }
}
