using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipItems : MonoBehaviour, IEndDragHandler, IDropHandler {
    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("hit");
        GameObject dropItem = eventData.pointerDrag.gameObject;
        Debug.Log(dropItem.name);
        dropItem.transform.parent = null;
        dropItem.transform.parent = this.transform;
        dropItem.transform.position = this.transform.position;
    }
}
