using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private ItemSlot myItemSlot = null;
    private Item draggingItem = null;

    private Image bufferDraggingImage = null;

    public event Action OnBeginDragEvent;

    private void Awake() {
        myItemSlot = GetComponent<ItemSlot>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (myItemSlot.currentItem) {
            draggingItem = myItemSlot.currentItem;
            bufferDraggingImage = new GameObject("buffer image").AddComponent<Image>();
            bufferDraggingImage.transform.SetParent(FindObjectOfType<Canvas>().transform);
            bufferDraggingImage.sprite = myItemSlot.image.sprite;
            bufferDraggingImage.transform.localScale = myItemSlot.image.transform.localScale;
            myItemSlot.RemoveItem();
            OnBeginDragEvent?.Invoke();
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (draggingItem == null) return;

        bufferDraggingImage.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (draggingItem == null) return;

        ItemSlot targetSlot = null;

        foreach(RaycastResult r in RaycastMouse()) {
            ItemSlot otherSlot = r.gameObject.GetComponentInParent<ItemSlot>();

            if (otherSlot != null && otherSlot != myItemSlot) {
                targetSlot = otherSlot;
                break;
            }
        }

        if (targetSlot != null) {
            if (!targetSlot.AddItem(draggingItem)) {
                myItemSlot.AddItem(draggingItem);
            }
        }
        else {
            myItemSlot.AddItem(draggingItem);
        }

        myItemSlot.image.transform.SetParent(myItemSlot.transform);
        myItemSlot.image.transform.localPosition = Vector2.zero;
        Destroy(bufferDraggingImage.gameObject);
    }

     public List<RaycastResult> RaycastMouse(){
         
         PointerEventData pointerData = new PointerEventData (EventSystem.current)
         {
             pointerId = -1,
         };
         
         pointerData.position = Input.mousePosition;
 
         List<RaycastResult> results = new List<RaycastResult>();
         EventSystem.current.RaycastAll(pointerData, results);
         
         return results;
     }
}
