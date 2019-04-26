using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Circle))]
public class CircleEditor : Editor
{
    public Circle circle;
    public int vertexcount;
    public GameObject source;
    static float radius = 3.0f;

    private float snap = 1f;

    private void OnSceneGUI()
    {

        circle = Selection.activeGameObject?.GetComponent<Circle>();

        if (circle != null)
        {
            EditorGUI.BeginChangeCheck();

            circle.SetupCircle();

            radius = circle.radius;
            radius = Handles.RadiusHandle(Quaternion.identity, circle.transform.position, radius);
            circle.radius = radius;

            vertexcount = circle.vertexCount;
            vertexcount = (int)Handles.ScaleSlider(vertexcount, circle.transform.position, -Vector3.right, Quaternion.identity, (float)1, snap);
            circle.vertexCount = vertexcount;

            EditorGUI.EndChangeCheck();

        }


    }


}
