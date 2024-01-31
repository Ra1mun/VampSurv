using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class ProjectileCurveMovement : ProjectileMovement
{
    [SerializeField] private List<Vector2> _controlPoints = new List<Vector2>();

    private float _speed => _projectile.Speed;
    private float movement = 0f;
    [SerializeField] float _deflectionCoefficientVertical;
    [SerializeField] float _deflectionCoefficientHorizontal;

    private void Start()
    {
        Vector2 localDirection = _projectile.TargetPosition - _projectile.OriginPosition;
        Vector2 localNormal = Vector2.Perpendicular(localDirection);
        _controlPoints.Add(_projectile.OriginPosition);

        _controlPoints.Add((localDirection * _deflectionCoefficientHorizontal
                + localNormal * _deflectionCoefficientVertical) + _projectile.OriginPosition);
        _controlPoints.Add((localDirection * _deflectionCoefficientHorizontal
                + (-localNormal) * _deflectionCoefficientVertical) + _projectile.OriginPosition);

        _controlPoints.Add(_projectile.OriginPosition);
    }
    protected override void Move()
    {
        if (movement < 1f)
        {
            movement += Time.deltaTime * _speed;
            Vector2 position = CalculateBezierPoint(movement, _controlPoints);
            transform.position = position;
        }
        else
        {
            _projectile.DisposeProjectile();
        }
    }
    Vector2 CalculateBezierPoint(float t, List<Vector2> points)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector2 p = uuu * points[0];
        p += 3f * uu * t * points[1];
        p += 3f * u * tt * points[2];
        p += ttt * points[3];

        return p;
    }
}
