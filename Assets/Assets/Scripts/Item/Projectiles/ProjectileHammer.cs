using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHammer : Projectile
{
    protected override void ManualDispose()
    {
        
    }
    protected override void OnTargetCollision(Collider2D collision, UnitDamageable damageable)
    {
        damageable.ApplyDamage(_damage);
    }
}
