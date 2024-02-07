using UnityEngine;

namespace Core.Item.Projectiles.PorjectileMove
{
    [RequireComponent(typeof(Projectile))]
    public abstract class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] protected Projectile _projectile;
        [SerializeField] protected Rigidbody2D projectileRigidbody;

        private void FixedUpdate()
        {
            Move();
        }

        protected virtual void Move()
        {
        }
    }
}