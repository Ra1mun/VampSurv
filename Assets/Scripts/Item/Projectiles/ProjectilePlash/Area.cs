using UnityEngine;

namespace Assets.Scripts.Item.Projectiles.ProjectilePlash
{
    public abstract class Area : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;

        [SerializeField] protected PeriodicalDamageDealer _damageDealer;

        protected float _radius;
        protected int _damage;
        public int Damage => _damage;

        public bool IsAreaDisposed;
        public virtual void Initialize(float radius, int damage)
        {
            _radius = radius;
            _damage = damage;
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (IsAreaDisposed)
                return;
            if (collision.gameObject.TryGetComponent(out global::Unit.Unit unit))
            {
                if (1 << collision.gameObject.layer == _targetLayerMask.value)
                {
                    OnTargetCollision(collision, unit);
                }
            }
            else
            {
                OnOtherCollision(collision);
            }
            OnAnyCollision(collision);
        }
        public void DisposeArea()
        {
            OnProjectileDispose();
            Destroy(gameObject);
            IsAreaDisposed = true;
            Debug.Log("Plash Disposed");
        }
        protected virtual void OnProjectileDispose() { }
        protected virtual void OnAnyCollision(Collider2D collision) { }
        protected virtual void OnOtherCollision(Collider2D collision) { }
        protected virtual void OnTargetCollision(Collider2D collision, global::Unit.Unit unit) { }
        protected virtual void ManualDispose() { }
    }
}
