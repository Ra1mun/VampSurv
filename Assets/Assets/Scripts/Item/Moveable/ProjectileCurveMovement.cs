using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class ProjectileCurveMovement : ProjectileMovement
{
    [SerializeField] private List<Transform> _controlPoints = new List<Transform>();

    private float _speed => _projectile.Speed; 

    private float movement = 0f;

    protected override void Move()
    {
        movement += Time.deltaTime / _speed;
        Vector3 position = CalculateBezierPoint(movement, _controlPoints);
        transform.position = position;
    }
    Vector3 CalculateBezierPoint(float t, List<Transform> points)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * points[0].position; 
        p += 3f * uu * t * points[1].position; 
        p += 3f * u * tt * points[2].position; 
        p += ttt * points[3].position; 

        return p;
    }
}
