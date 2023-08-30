using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDisposeType _disposeType = ProjectileDisposeType.OnAnyCollision;

    [SerializeField] private LayerMask _targetLayerMask;

    protected float _radius;
    protected int _damage;
    protected float _speed;
    protected Vector2 _targetPosition;
    protected Vector2 _originPosition;

    public Vector2 TargetPosition => _targetPosition;
    public Vector2 OriginPosition => _originPosition;
    public float Speed => _speed;
    
    public ProjectileDisposeType DisposeType => _disposeType;

    public bool IsProjectileDisposed;
    private void Update()
    {
        ManualDispose();
    }
    public void Initialize(float speed, float radius, int damage, Vector2 target, Vector2 originPosition)
    {
        
        _radius = radius;
        _damage = damage;
        _speed = speed;
        _targetPosition = target;
        _originPosition = originPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsProjectileDisposed)
            return;
        if (collision.gameObject.TryGetComponent(out EntityDamageable damageable))
        {
            if (1 << collision.gameObject.layer == _targetLayerMask.value)
            {
                OnTargetCollision(collision, damageable);

                if (_disposeType == ProjectileDisposeType.OnTargetCollision)
                {
                    DisposeProjectile();
                }
            }
        }
        else
        {
            OnOtherCollision(collision);
            if (_disposeType == ProjectileDisposeType.OnNotTargetCollision)
                DisposeProjectile();
        }

        OnAnyCollision(collision);

        if (_disposeType == ProjectileDisposeType.OnAnyCollision)
        {
            DisposeProjectile();
        }

    }
    public void DisposeProjectile()
    {
        OnProjectileDispose();
        Destroy(gameObject);
        IsProjectileDisposed = true;
    }

    protected virtual void OnProjectileDispose() { }
    protected virtual void OnAnyCollision(Collider2D collision) { }
    protected virtual void OnOtherCollision(Collider2D collision) { }
    protected virtual void OnTargetCollision(Collider2D collision, EntityDamageable damageable) { }
    protected virtual void ManualDispose(){ }
}
