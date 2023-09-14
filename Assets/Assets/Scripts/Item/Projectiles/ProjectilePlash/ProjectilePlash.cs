using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectilePlash : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayerMask;

    [SerializeField] protected PeriodicalDamageDealer _damageDealer;

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
    private void Awake()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsProjectileDisposed)
            return;
        if (collision.gameObject.TryGetComponent(out Entity entity))
        {
            if (1 << collision.gameObject.layer == _targetLayerMask.value)
            {
                OnTargetCollision(collision, entity);
            }
        }
        else
        {
            OnOtherCollision(collision);
        }
        OnAnyCollision(collision);
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
    protected virtual void OnTargetCollision(Collider2D collision, Entity entity){    }
    protected virtual void ManualDispose() { }
}
