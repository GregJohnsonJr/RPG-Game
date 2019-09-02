using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggingUI : MonoBehaviour, IBeginDragHandler, IDragHandler , IEndDragHandler {
    GameObject parent;
    Vector2 offset;
    CameraController controller;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (controller)
            controller.isDragged = true;
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        this.transform.position = eventData.position - offset;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position - offset;
        controller = Camera.main.GetComponent<CameraController>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (controller)
            controller.isDragged = false;
    }

    void Start()
    {
        controller = Camera.main.GetComponent<CameraController>();
        if (controller)
            controller.isDragged = false;

    }
}
