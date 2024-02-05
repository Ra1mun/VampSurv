using UnityEngine;

namespace Assets.Scripts.Item.Projectiles.PorjectileMove
{
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
}
