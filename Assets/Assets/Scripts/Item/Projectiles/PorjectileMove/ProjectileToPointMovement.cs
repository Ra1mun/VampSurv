using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileToPointMovement : ProjectileMovement
{
    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _projectile.TargetPosition,
            _projectile.Speed * Time.deltaTime);

        if((Vector2)transform.position == _projectile.TargetPosition)
            _projectile.DisposeProjectile();
    }
}
