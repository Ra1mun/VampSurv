using System;
using UnityEngine;

public abstract class EntityDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private EntityHealth _entityHealth;

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException(nameof(damage));

        var totalDamage = ProcessDamage(damage);
        
        _entityHealth.CurrentHealth -= damage;
    }

    protected virtual int ProcessDamage(int damage)
    {
        return damage;
    }
}
