using Core.Unit;
using UnityEngine;

namespace Core.Item.Projectiles
{
    public class ProjectileLinear : Projectile
    {
        protected override void ManualDispose()
        {
            var tempDistance = Vector2.Distance(_originPosition, gameObject.transform.position);
            if (tempDistance > _stats.GetStats().AttackDistance)
                DisposeProjectile();
            //Need optimization. Sqrt func every frame is very rich. Might be worth adding coroutine.
        }

        protected override void OnTargetCollision(Collider2D collision, UnitDamageable damageable)
        {
            damageable.ApplyDamage(_stats.GetStats().Damage);
        }
    }
}