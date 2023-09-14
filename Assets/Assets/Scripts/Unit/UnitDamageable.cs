using System;
using UnityEngine;

public abstract class UnitDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitHealth unitHealth;

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException(nameof(damage));

        var totalDamage = ProcessDamage(damage);
        
        unitHealth.CurrentHealth -= damage;
    }

    protected virtual int ProcessDamage(int damage)
    {
        return damage;
    }
}
