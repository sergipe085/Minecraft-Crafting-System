using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public ItemSlot[] itemSlots = null;
    public CraftingManager craftingManager = null;

    private void Start() {
        itemSlots = GetComponentInChildren<ItemSlots>().itemSlots;

        foreach(ItemSlot slot in itemSlots) {
            slot.OnLeftClickEvent += OnSlotLeftClicked;
        }
    }

    private void OnSlotLeftClicked(ItemSlot clickedSlot) {
        craftingManager.itemToAdd = clickedSlot.currentItem;
    }
}
