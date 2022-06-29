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
    public event Action OnAddItemEvent;
    public event Action OnRemoveItemEvent;

    public int stack = 0;

    private void Start() {
        if (currentItem != null) {
            image.sprite = currentItem.icon;
        }
        else {
            image.enabled = false;
        }
    }

    public bool AddItem(Item newItem) {
        if (newItem == null) return false;

        if (currentItem == newItem) {
            stack++;
            return true;
        }

        currentItem = newItem;
        image.sprite = currentItem.icon;
        image.enabled = true;
        OnAddItemEvent?.Invoke();
        stack++;
        return true;
    }

    public void RemoveItem() {
        stack--;

        if (stack <= 0) {
            currentItem = null;
            image.sprite = null;
            image.enabled = false;
            OnRemoveItemEvent?.Invoke();
        }
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
