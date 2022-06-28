using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting/Recipe")]
public class Recipe : ScriptableObject
{
    public Item outputItem = null;
    public Hash hash = new();
    public List<Item> itemSlots = new();

    public void GenerateHash() {
        foreach (Item item in itemSlots) {
            if (item == null) {
                hash.hashString += "0";
                continue;
            }

            hash.hashString += item.itemId.ToString();
            hash.notNullCounter += 1;
        }
    }
}