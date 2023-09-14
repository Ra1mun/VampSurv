using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLinearSpear : Projectile
{
    protected override void ManualDispose()
    {
        float tempDistance = Vector2.Distance(_originPosition, gameObject.transform.position);
        if ( tempDistance > _radius)
            DisposeProjectile();
        //Need optimization. Sqrt func every frame is very rich. Might be worth adding coroutine.
    }
    protected override void OnTargetCollision(Collider2D collision, EntityDamageable damageable)
    {
        damageable.ApplyDamage(_damage);
    }
}
