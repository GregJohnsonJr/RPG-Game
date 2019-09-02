using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellBookButtonScript : MonoBehaviour, IPointerDownHandler
{
    public int ID;
    [HideInInspector]
    public string description;
    [HideInInspector]
    public GameObject abilityInformation;
    public void OnPointerDown(PointerEventData eventData)
    {
        abilityInformation.GetComponentInChildren<Text>().text = description;
    }
}



