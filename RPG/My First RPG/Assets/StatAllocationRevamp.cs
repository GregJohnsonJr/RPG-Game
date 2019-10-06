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
    bool isDisplayed;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isPlus)
        {
            isDisplayed = true;
            descText.text = statDescriptions[statNum];
            var screenPoint = Input.mousePosition;
            screenPoint.z = 0f; //distance of the plane from the camera
            descText.gameObject.transform.position = eventData.position;
        }
    }
   
    public void OnPointerExit(PointerEventData eventData)
    {
        if(isDisplayed)
        {
            isDisplayed = false;
            descText.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
