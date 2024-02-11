using UnityEngine;

namespace Core.Item.Projectiles.PorjectileMove
{
    [RequireComponent(typeof(Projectile))]
    public abstract class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] protected Projectile _projectile;
        [SerializeField] protected Rigidbody2D projectileRigidbody;

        protected bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

        private void FixedUpdate()
        {
            if (IsPaused)
            {
                return;
            }
            
            Move();
        }

        protected abstract void Move();
    }
}