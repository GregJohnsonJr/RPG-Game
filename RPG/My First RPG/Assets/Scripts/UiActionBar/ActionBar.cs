using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionBar : MonoBehaviour , IBeginDragHandler , IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
    Vector2 offset;
    GameObject[] abilityHolder;
    GameObject thisHolder;
    // Use this for initialization
    void Start () {
        abilityHolder = GameObject.FindGameObjectsWithTag("AbilityHolder");
		// i believe i need point and drag from the inventory to the action bar
        // Makes the action bar and is moveable around the scenes
        // Allows me to click the skill to use it and i can move one to the other, can use the logic from the other script
        // Probs add the ui element and we good
	}
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        this.transform.SetParent(this.transform.parent.parent);
        this.transform.position = eventData.position - offset;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position - offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //this.transform.SetParent();
        //this.transform.position = inv.slots[slot].transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

  
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AbilityHolder")
            Debug.Log("Collided");


    }
}
