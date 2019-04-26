using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour
{

    public Transform target;
    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;
    public bool circleFillscreen;
    public float distance = 10f;
    private int minValue = 3;
    private int maxValue = 100;

    private LineRenderer lineRenderer;

    private void Awake()
    {

        SetupCircle();

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertexCount + 1; i++)
        {

            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;

        }
    }

    private void Update()
    {
        Vector3 flatTargetPositioon = target.position;
    }

    private void OnDrawGizmosSelected()
    {
        Color oldColor = Gizmos.color;

        Gizmos.color = new Color(0.5f, 0f, 0f, 0.5f);

        if (target)
        {
            Gizmos.DrawLine(transform.position, target.position);
            Gizmos.DrawSphere(target.position, 1.5f);
        }

        Gizmos.color = oldColor;
    }

    public void SetupCircle()
    {

        vertexCount = Mathf.Clamp(vertexCount, minValue, maxValue);


        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = lineWidth;

        if (circleFillscreen)
        {
            radius = Vector3.Distance(Camera.main.ScreenToViewportPoint(new Vector3(0f, Camera.main.pixelRect.yMax, 0f)), Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMin, 9f))) * 0.5f - lineWidth;
        }
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

#endif 
}
