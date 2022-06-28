using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{
    private ItemContainer comp;

    public void OnEnable() {
        comp = (ItemContainer) target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Generate Items ID's")) {
            comp.GenerateItemIds();
        }

        base.OnInspectorGUI();

    }
}
