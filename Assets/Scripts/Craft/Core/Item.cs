using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Item", menuName = "Crafting/Item")]
public class Item : ScriptableObject
{
    public string itemName = "ItemTest";
    public int itemId;
    public Sprite icon = null;
}
