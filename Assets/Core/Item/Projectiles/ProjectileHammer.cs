using Core.Unit;
using UnityEngine;

namespace Core.Item.Projectiles
{
    public class ProjectileHammer : Projectile
    {
        protected override void ManualDispose()
        {
        }

        protected override void OnTargetCollision(Collider2D collision, UnitDamageable damageable)
        {
            damageable.ApplyDamage(_stats.GetStats().Damage);
        }
    }
}