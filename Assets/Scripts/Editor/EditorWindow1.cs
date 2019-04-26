using UnityEditor;
using UnityEngine;

public class EditorWindow1 : EditorWindow
{
    public Circle circle;
    public int vertexcount;
    public GameObject source;
    static float radius = 3.0f;

    [MenuItem("Window/CircleEditorWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<EditorWindow1>("CircleEditorWindow");
    }


    private void OnGUI()
    {
        source = (GameObject)EditorGUILayout.ObjectField(source, typeof(Object), true);


        circle = Selection.activeGameObject?.GetComponent<Circle>();


        if (circle != null)
        {
                circle.SetupCircle();
            if (GUILayout.Button("Start Method"))
            {
            }
            radius = circle.radius;
            radius = EditorGUILayout.Slider(radius, 0f, 8f);
            circle.radius = radius;

            vertexcount = circle.vertexCount;
            vertexcount = EditorGUILayout.IntSlider(vertexcount, 3, 100);

            circle.vertexCount = vertexcount;

        }
        


        if (source == null)
        {
            ShowNotification(new GUIContent("No object selected for searching"));
        }
        else
        {
            source.GetComponent<Circle>();
            source.GetComponent<LineRenderer>();
        }
    }



}
