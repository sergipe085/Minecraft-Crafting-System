using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Button btn = null;
    public Image image = null;
    
    public Item currentItem = null;

    public event Action<ItemSlot> OnLeftClickEvent;
    public event Action<ItemSlot> OnRightClickEvent;

    private void Start() {
        if (currentItem != null) {
            image.sprite = currentItem.icon;
        }
    }

    public void AddItem(Item newItem) {
        if (newItem == null) return;

        currentItem = newItem;
        image.sprite = currentItem.icon;
    }

    public void RemoveItem() {
        currentItem = null;
        image.sprite = null;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            OnLeftClickEvent?.Invoke(this);
        }

        if (eventData.button == PointerEventData.InputButton.Right) {
            OnRightClickEvent?.Invoke(this);
        }
    }
}
