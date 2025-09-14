using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DesiredSizeTool))]
public class DesiredSizeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DesiredSizeTool tool = (DesiredSizeTool)target;
        MeshFilter meshFilter = tool.GetComponentInChildren<MeshFilter>();

        if (meshFilter)
        {
            Vector3 meshSize = meshFilter.sharedMesh.bounds.size;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Mesh Size", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("X", GUILayout.Width(19));
            EditorGUILayout.SelectableLabel(
                meshSize.x.ToString("F10"),
                EditorStyles.textField,
                GUILayout.Height(19)
            );
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Y", GUILayout.Width(19));
            EditorGUILayout.SelectableLabel(
                meshSize.y.ToString("F10"),
                EditorStyles.textField,
                GUILayout.Height(19)
            );
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Z", GUILayout.Width(19));
            EditorGUILayout.SelectableLabel(
                meshSize.z.ToString("F10"),
                EditorStyles.textField,
                GUILayout.Height(19)
            );
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
        }
        else
        {
            EditorGUILayout.HelpBox("MeshFilter Not Found!", MessageType.Warning);
        }

        if (GUILayout.Button("Apply Desired Size"))
        {
            Undo.RecordObject(tool.transform, "Apply Desired Size");
            tool.Apply();
            EditorUtility.SetDirty(tool.transform);
        }
    }
}
