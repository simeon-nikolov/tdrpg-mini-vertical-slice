using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BoneOffsetTunerAdvanced))]
public class BoneOffsetTunerEditor : Editor
{
    bool showGeneralSettings = true;
    bool showOffsetSettings = true;
    bool showDebugTools = true;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        BoneOffsetTunerAdvanced tuner = (BoneOffsetTunerAdvanced)target;

        // GENERAL SETTINGS
        showGeneralSettings = EditorGUILayout.Foldout(showGeneralSettings, "🧩 General Settings", true);
        if (showGeneralSettings)
        {
            EditorGUI.indentLevel++;
            tuner.upperArmBone = (Transform)EditorGUILayout.ObjectField("Upper Arm Bone", tuner.upperArmBone, typeof(Transform), true);
            tuner.handBone = (Transform)EditorGUILayout.ObjectField("Hand Bone", tuner.handBone, typeof(Transform), true);
            EditorGUI.indentLevel--;
        }

        GUILayout.Space(10);

        // OFFSET SETTINGS
        showOffsetSettings = EditorGUILayout.Foldout(showOffsetSettings, "🎯 Offset Settings", true);
        if (showOffsetSettings)
        {
            EditorGUI.indentLevel++;

            tuner.applyOffsets = EditorGUILayout.Toggle("Apply Offsets", tuner.applyOffsets);

            EditorGUILayout.LabelField("Upper Arm Offset", EditorStyles.boldLabel);
            tuner.upperArmRotationOffset.x = EditorGUILayout.Slider("Upper Arm X", tuner.upperArmRotationOffset.x, -180f, 180f);
            tuner.upperArmRotationOffset.y = EditorGUILayout.Slider("Upper Arm Y", tuner.upperArmRotationOffset.y, -180f, 180f);
            tuner.upperArmRotationOffset.z = EditorGUILayout.Slider("Upper Arm Z", tuner.upperArmRotationOffset.z, -180f, 180f);

            GUILayout.Space(5);

            EditorGUILayout.LabelField("Hand Offset", EditorStyles.boldLabel);
            tuner.handRotationOffset.x = EditorGUILayout.Slider("Hand X", tuner.handRotationOffset.x, -180f, 180f);
            tuner.handRotationOffset.y = EditorGUILayout.Slider("Hand Y", tuner.handRotationOffset.y, -180f, 180f);
            tuner.handRotationOffset.z = EditorGUILayout.Slider("Hand Z", tuner.handRotationOffset.z, -180f, 180f);

            EditorGUI.indentLevel--;
        }

        GUILayout.Space(10);

        // DEBUG TOOLS
        showDebugTools = EditorGUILayout.Foldout(showDebugTools, "🛠 Debug / Tools", true);
        if (showDebugTools)
        {
            EditorGUI.indentLevel++;
            if (GUILayout.Button("Reset to Initial Pose"))
            {
                Undo.RecordObject(tuner.upperArmBone, "Reset Upper Arm Rotation");
                Undo.RecordObject(tuner.handBone, "Reset Hand Rotation");

                tuner.upperArmBone.localEulerAngles = tuner.initialUpperArmRotation;
                tuner.handBone.localEulerAngles = tuner.initialHandRotation;
            }

            if (GUILayout.Button("Save Current Pose as New Base"))
            {
                Undo.RecordObject(tuner, "Save New Initial Pose");
                tuner.SaveInitialRotations();
            }

            EditorGUI.indentLevel--;
        }

        GUILayout.Space(10);

        Color originalColor = GUI.color;
        GUI.color = new Color(1f, 0.5f, 0f);

        if (GUILayout.Button("Reset Offsets"))
        {
            Undo.RecordObject(tuner, "Reset Offsets");
            tuner.upperArmRotationOffset = Vector3.zero;
            tuner.handRotationOffset = Vector3.zero;
        }

        GUI.color = originalColor;

        if (GUI.changed)
        {
            EditorUtility.SetDirty(tuner);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
