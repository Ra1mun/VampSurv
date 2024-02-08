namespace Core.Item.Projectiles.PorjectileMove
{
    public class ProjectileLinearMovement : ProjectileMovement
    {
        protected override void Move()
        {
            projectileRigidbody.velocity = (_projectile.TargetPosition - _projectile.OriginPosition).normalized
                                           * _projectile._stats.GetStats().MoveSpeed;
        }
    }
}