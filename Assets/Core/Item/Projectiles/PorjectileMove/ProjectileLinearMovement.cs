namespace Core.Item.Projectiles.PorjectileMove
{
    public class ProjectileLinearMovement : ProjectileMovement
    {
        protected override void Move()
        {
            if(IsPaused)
            {
                return;
            }
            projectileRigidbody.velocity = (_projectile.TargetPosition - _projectile.OriginPosition).normalized
                                           * _projectile._stats.GetStats().MoveSpeed;
        }
    }
}