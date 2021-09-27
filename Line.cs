using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private EdgeCollider2D _edgeCollider2D;

    private List<Vector2> points = new List<Vector2>();
    private void Start()
    {
        _edgeCollider2D.transform.position -= transform.position;
    }
    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos))
            return;
        points.Add(pos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, pos);
        _edgeCollider2D.points = points.ToArray();
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_lineRenderer.positionCount == 0)
            return true;
        return Vector2.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1), pos) > Drawer.RESOLUTION;
    }
}
