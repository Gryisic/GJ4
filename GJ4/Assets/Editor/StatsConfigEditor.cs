#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using GJ4.Battle;
using UnityEngine;
using System;
using System.Collections.Generic;
using static GJ4.Utils.Enums;

[CustomEditor(typeof(StatsConfig))]
public class StatsConfigEditor : Editor
{
    private SerializedProperty _stats;

    private ReorderableList _statsList;

    private void OnEnable()
    {
        _stats = serializedObject.FindProperty(nameof(_stats));

        if (_statsList == null)
            _statsList = GenerateList();
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        serializedObject.Update();

        _statsList.DoLayoutList();

        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
    }

    private void DrawHeader(Rect rect) => EditorGUI.LabelField(rect, "Stats");

    private void DrawElements(Rect rect, int index, bool isActive, bool isFocused) 
    {
        string type = "_type";
        string value = "_value";

        SerializedProperty element = _statsList.serializedProperty.GetArrayElementAtIndex(index);

        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight), 
            element.FindPropertyRelative(type), 
            GUIContent.none);

        EditorGUI.LabelField(
            new Rect(rect.x + rect.width / 2, rect.y, rect.width / 3, EditorGUIUtility.singleLineHeight),
            "Value:");

        EditorGUI.PropertyField(
            new Rect(rect.x + rect.width / 1.5f, rect.y, rect.width / 4, EditorGUIUtility.singleLineHeight),
            element.FindPropertyRelative(value),
            GUIContent.none);
    }

    private ReorderableList GenerateList() 
    {
        var stats = new ReorderableList(serializedObject, _stats, true, true, false, false);
        var statTypes = Enum.GetValues(typeof(StatType));

        stats.list = new List<Stat>();

        serializedObject.Update();

        for (int i = 0; i < statTypes.Length; i++)
        {
            if (stats.serializedProperty.arraySize < statTypes.Length)
                stats.serializedProperty.arraySize++;

            var element = stats.serializedProperty.GetArrayElementAtIndex(i);
            element.FindPropertyRelative("_type").enumValueIndex = (int)statTypes.GetValue(i);
        }

        serializedObject.ApplyModifiedProperties();

        stats.drawHeaderCallback = DrawHeader;
        stats.drawElementCallback = DrawElements;

        return stats;
    }
}
#endif
