using System.Collections.Generic;
using Core.Item.Projectiles.PorjectileMove;
using UnityEngine;

namespace Core.Item.Moveable
{
    public class ProjectileCurveMovement : ProjectileMovement
    {
        [SerializeField] private List<Vector2> _controlPoints = new();
        [SerializeField] private float _deflectionCoefficientVertical;
        [SerializeField] private float _deflectionCoefficientHorizontal;
        private float movement;

        private float _speed => _projectile.Speed;

        private void Start()
        {
            var localDirection = _projectile.TargetPosition - _projectile.OriginPosition;
            var localNormal = Vector2.Perpendicular(localDirection);
            _controlPoints.Add(_projectile.OriginPosition);

            _controlPoints.Add(localDirection * _deflectionCoefficientHorizontal
                               + localNormal * _deflectionCoefficientVertical + _projectile.OriginPosition);
            _controlPoints.Add(localDirection * _deflectionCoefficientHorizontal
                               + -localNormal * _deflectionCoefficientVertical + _projectile.OriginPosition);

            _controlPoints.Add(_projectile.OriginPosition);
        }

        protected override void Move()
        {
            if (movement < 1f)
            {
                movement += Time.deltaTime * _speed;
                var position = CalculateBezierPoint(movement, _controlPoints);
                transform.position = position;
            }
            else
            {
                _projectile.DisposeProjectile();
            }
        }

        private Vector2 CalculateBezierPoint(float t, List<Vector2> points)
        {
            var u = 1f - t;
            var tt = t * t;
            var uu = u * u;
            var uuu = uu * u;
            var ttt = tt * t;

            var p = uuu * points[0];
            p += 3f * uu * t * points[1];
            p += 3f * u * tt * points[2];
            p += ttt * points[3];

            return p;
        }
    }
}