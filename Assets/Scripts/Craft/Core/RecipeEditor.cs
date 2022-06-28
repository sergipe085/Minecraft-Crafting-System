using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Recipe))]
public class RecipeEditor : Editor
{
    private Recipe comp;

    public void OnEnable() {
        comp = (Recipe) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate Recipe Hash")) {
            comp.GenerateHash();
        }
    }
}
