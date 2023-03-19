using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allies : Entity, IHealth, IDamageable
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public override event Action<Entity> OnDie;

    private float _moveSpeed;

    public void Initialize(float moveSpeed, int maxHealth, float attackDistance,
        float attackSpeed, int damage, EntityType type)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _moveSpeed = moveSpeed;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _type = type;
    }
    private bool IsAlive()
    {
        return _currentHealth > 0;
    }

    public override void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_maxHealth, _currentHealth);

        if (!IsAlive())
        {
            OnDie?.Invoke(this);
        }
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {
    }
}

