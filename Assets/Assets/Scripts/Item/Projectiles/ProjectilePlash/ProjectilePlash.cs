using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectilePlash : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayerMask;

    protected float _radius;
    protected int _damage;
    protected float _speed;

    public int Damage => _damage;

    public bool IsProjectileDisposed;

    public void Initialize(float speed, float radius, int damage)
    {
        _radius = radius;
        _damage = damage;
        _speed = speed;
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
            }
        }
        else
        {
            OnOtherCollision(collision);
        }
        OnAnyCollision(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsProjectileDisposed)
            return;
        if (collision.gameObject.TryGetComponent(out EntityDamageable damageable))
        {
            if (1 << collision.gameObject.layer == _targetLayerMask.value)
            {
                OnTargetCollisionExit(collision, damageable);
            }
        }
        else
        {
            OnOtherCollisionExit(collision);
        }
        OnAnyCollisionExit(collision);
    }
    public void DisposeProjectile()
    {
        OnProjectileDispose();
        Destroy(gameObject);
        IsProjectileDisposed = true;
        Debug.Log("Plash Disposed");
    }
    protected virtual void OnProjectileDispose() { }
    protected virtual void OnAnyCollision(Collider2D collision) { }
    protected virtual void OnOtherCollision(Collider2D collision) { }
    protected virtual void OnTargetCollision(Collider2D collision, EntityDamageable damageable){    }

    protected virtual void OnAnyCollisionExit(Collider2D collision) { }
    protected virtual void OnOtherCollisionExit(Collider2D collision) { }
    protected virtual void OnTargetCollisionExit(Collider2D collision, EntityDamageable damageable) { }

    protected virtual void ManualDispose() { }
}
