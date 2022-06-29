using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public ItemContainer container = null;
    public ItemSlot[] itemSlots;
    public ItemSlot itemCrafted = null;
    public Hash currentHash = null;
    public Item itemToAdd = null;

    private void Start() {
        itemSlots = GetComponentInChildren<ItemSlots>().itemSlots;

        foreach(ItemSlot slot in itemSlots) {
            slot.OnLeftClickEvent += OnSlotLeftClicked;
            slot.OnRightClickEvent += OnSlotRightClicked;
            slot.OnAddItemEvent += UpdateCraftedItem;
            slot.OnRemoveItemEvent += UpdateCraftedItem;
        }

        itemCrafted.GetComponent<Draggable>().OnBeginDragEvent += Clear;
    }

    private void OnSlotLeftClicked(ItemSlot slot) {
        slot.AddItem(itemToAdd);
        UpdateCraftedItem();
    }

    private void OnSlotRightClicked(ItemSlot slot) {
        slot.RemoveItem();
        UpdateCraftedItem();
    }

    private void UpdateCraftedItem() {
        GenerateHash();
        
        Recipe recipe = SearchRecipe();
        if (recipe == null) {
            itemCrafted.RemoveItem();
        }
        else {
            itemCrafted.AddItem(recipe.outputItem);
        }
    }

    public Recipe SearchRecipe() {
        foreach (Recipe recipe in container.recipes) {
            if (Hash.CompareHashes(currentHash, recipe.hash)) {
                return recipe;
            }
        }
        return null;
    }

    public void Clear() {
        foreach (ItemSlot slot in itemSlots) {
            slot.Clear();
        }
    }

    public void GenerateHash() {
        currentHash = new Hash();

        foreach(ItemSlot slot in itemSlots) {
            if (slot.currentItem == null) {
                currentHash.hashString += "0";
                continue;
            }
            currentHash.hashString += slot.currentItem.itemId.ToString();
            currentHash.notNullCounter += 1;
        }
    }
}
