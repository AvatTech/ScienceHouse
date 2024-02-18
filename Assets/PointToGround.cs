using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToGround : MonoBehaviour
{
    public Transform pointTransform; // The point from which to draw the vector
    public LayerMask groundLayer; // Which layers constitute the ground
    public bool drawLineAlways = true; // Whether to draw the line even if no ground is found
    public LineRenderer lineRenderer; // Component for visualizing the vector
    public Color lineColor = Color.red; // Color of the vector line
    public float lineWidth = 0.02f; // Width of the vector line

    private void Update()
    {
        Vector3 groundHitPoint = Vector3.down * Mathf.Infinity; // Initialize with infinite downward direction
        bool hitGround = Physics.Raycast(pointTransform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer);

        if (hitGround)
        {
            groundHitPoint = hit.point;
        }

        if (drawLineAlways || hitGround)
        {
            lineRenderer.SetPosition(0, pointTransform.position);
            lineRenderer.SetPosition(1, groundHitPoint);
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
        }
    }
}
