using System;
using UnityEngine;

public abstract class UnitDamageable : MonoBehaviour, IDamageable
{
    [SerializeField] private UnitHealth _unitHealth;

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException(nameof(damage));

        var totalDamage = ProcessDamage(damage);
        
        _unitHealth.CurrentHealth -= damage;
        Debug.Log(_unitHealth.CurrentHealth);
    }

    protected virtual int ProcessDamage(int damage)
    {
        return damage;
    }
}
