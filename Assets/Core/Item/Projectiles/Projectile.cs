using Core.Unit;
using UnityEngine;

namespace Core.Item.Projectiles
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileDisposeType _disposeType = ProjectileDisposeType.OnAnyCollision;
        [SerializeField] private LayerMask _targetLayerMask;
        
        [SerializeField] protected Transform _projectileContainer;
        [SerializeField] protected Vector2 _targetPosition;

        [HideInInspector] public ItemStats _stats;

        protected Vector2 _originPosition;
        

        public bool IsProjectileDisposed;

        public Vector2 TargetPosition => _targetPosition;
        public Vector2 OriginPosition => _originPosition;

        public ProjectileDisposeType DisposeType => _disposeType;

        private void Update()
        {
            if (_disposeType == ProjectileDisposeType.Manual)
                ManualDispose();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsProjectileDisposed)
                return;

            if (collision.gameObject.TryGetComponent(out UnitDamageable damageable))
            {
                if (1 << collision.gameObject.layer == _targetLayerMask.value)
                {
                    OnTargetCollision(collision, damageable);
                    if (_disposeType == ProjectileDisposeType.OnTargetCollision) DisposeProjectile();
                }
            }
            else
            {
                OnOtherCollision(collision);
                if (_disposeType == ProjectileDisposeType.OnNotTargetCollision)
                    DisposeProjectile();
            }

            OnAnyCollision(collision);

            if (_disposeType == ProjectileDisposeType.OnAnyCollision) DisposeProjectile();
        }

        public void Initialize(Vector2 target, Vector2 originPosition, ItemStats stats)
        {
            _targetPosition = target;
            _originPosition = originPosition;
            _stats = stats;
        }

        public void DisposeProjectile()
        {
            OnProjectileDispose();
            Destroy(gameObject);
            IsProjectileDisposed = true;
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

        protected virtual void OnTargetCollision(Collider2D collision, UnitDamageable damageable)
        {
        }

        protected virtual void ManualDispose()
        {
        }
    }

    public enum ProjectileDisposeType
    {
        OnTargetCollision,
        OnAnyCollision,
        Manual,
        OnNotTargetCollision
    }
}