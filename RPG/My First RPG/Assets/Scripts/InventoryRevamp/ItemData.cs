using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemData : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Item item;
    public int amount;
    public int slot;
    
    
    private Vector2 offset;
    private InvetoryR inv;
    private ToolTip toolTip;
    CameraController controller;

     void Start()
     {
        inv = GameObject.Find("InventoryData").GetComponent<InvetoryR>();
        toolTip = inv.GetComponent<ToolTip>();
        controller = Camera.main.GetComponent<CameraController>();
        if(controller)
        controller.isDragged = false;
     }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(controller)
        controller.isDragged = true;
        if (item != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset;
            if(!this.gameObject.GetComponent<Canvas>())
            this.gameObject.AddComponent<Canvas>();
            this.gameObject.GetComponent<Canvas>().overrideSorting = true;
            this.gameObject.GetComponent<Canvas>().sortingOrder = 100;
            if (!this.gameObject.GetComponent<GraphicRaycaster>())
                this.gameObject.AddComponent<GraphicRaycaster>();
        }
        
    }

    // set the poition on the on pointer down evernt for picking up the object
    public void OnEndDrag(PointerEventData eventData)
    {
       
        this.transform.SetParent(inv.slots[slot].transform);
        this.transform.position = inv.slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(controller)
        controller.isDragged = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.Activate(item);  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        toolTip.DeActivate();
    }
}
