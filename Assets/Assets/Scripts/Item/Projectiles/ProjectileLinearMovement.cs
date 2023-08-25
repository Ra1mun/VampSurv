using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Projectile))]
public class ProjectileLinearMovement : MonoBehaviour
{
    [SerializeField] protected Projectile _projectile;
    [SerializeField] protected Rigidbody2D projectileRigidbody;
    private void FixedUpdate()
    {
        Move();
    }
    protected void Move()
    {
        projectileRigidbody.velocity = ((_projectile.TargetPosition - _projectile.OriginPosition).normalized
            * _projectile.Speed);
    }
}
