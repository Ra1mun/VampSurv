using System;
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

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (IsProjectileDisposed)
            return;
        if (collider.gameObject.TryGetComponent(out Unit unit))
        {
            if (1 << collider.gameObject.layer == _targetLayerMask.value)
            {
                OnTargetCollision(collider, unit);
            }
        }
        else
        {
            OnOtherCollision(collider);
        }
        OnAnyCollision(collider);
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
    protected virtual void OnTargetCollision(Collider2D collision, Unit unit){    }
    
    protected virtual void ManualDispose() { }
}
