using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLinearMovement : ProjectileMovement
{

    protected override void Move()
    {
        projectileRigidbody.velocity = ((_projectile.TargetPosition - _projectile.OriginPosition).normalized
            * _projectile.Speed);
    }
}
