using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Item.Projectiles
{
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
}
