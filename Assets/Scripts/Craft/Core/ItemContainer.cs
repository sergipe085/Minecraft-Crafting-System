using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Container", menuName = "Crafting/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<Item> items = new();
    public List<Recipe> recipes = new();

    public void GenerateItemIds() {
        int i = 1;
        foreach (Item item in items) {
            item.itemId = i;
            i++;
        }
    }
}
