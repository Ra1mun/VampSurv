using UnityEngine;

namespace Core.Item.Projectiles.ProjectilePlash
{
    public abstract class Area : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;

        [SerializeField] protected PeriodicalDamageDealer _damageDealer;


        public bool IsAreaDisposed;

        protected int _damage;

        protected float _radius;

        public int Damage => _damage;
        public bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (IsPaused)
            {
                return;
            }

            if (IsAreaDisposed)
                return;
            if (collision.gameObject.TryGetComponent(out Unit.Unit unit))
            {
                if (1 << collision.gameObject.layer == _targetLayerMask.value) OnTargetCollision(collision, unit);
            }
            else
            {
                OnOtherCollision(collision);
            }

            OnAnyCollision(collision);
        }

        public virtual void Initialize(float radius, int damage)
        {
            _radius = radius;
            _damage = damage;
        }

        public void DisposeArea()
        {
            OnProjectileDispose();
            Destroy(gameObject);
            IsAreaDisposed = true;
            Debug.Log("Plash Disposed");
        }

        protected virtual void OnProjectileDispose()
        {
        }

        protected virtual void OnAnyCollision(Collider2D collision)
        {
        }

        protected virtual void OnOtherCollision(Collider2D collision)
        {
        }

        protected virtual void OnTargetCollision(Collider2D collision, Unit.Unit unit)
        {
        }

        protected virtual void ManualDispose()
        {
        }
    }
}