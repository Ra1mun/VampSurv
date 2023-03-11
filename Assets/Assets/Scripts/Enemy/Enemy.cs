using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity, IHealth, IDamageable
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public override event Action<Entity> OnDie;

    private IDamageDealer _damageDealer;

    private float _moveSpeed;

    private Entity _target;
    
    private EnemyState _state;
    
    public void Initialize(float moveSpeed, int maxHealth, float attackDistance, float attackSpeed,
        int damage, EntityType type)
    {
        _moveSpeed = moveSpeed;
        _maxHealth = maxHealth;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _type = type;
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {
        switch (_state)
        {
            case EnemyState.LookForTarget:
                LookForTarget(targetFinder);
                break;
            case EnemyState.MoveToTarget:
                MoveToTarget();
                break;
            case EnemyState.AttackTarget:
                AttackTarget();
                break;
        }
    }

    private void LookForTarget(ITargetFinder targetFinder)
    {
        _target = targetFinder.FindTarget(this);
        if (_target == null)
            return;
        
        _state = EnemyState.MoveToTarget;
    }
    private void MoveToTarget()
    {
        if (_target == null)
        {
            _state = EnemyState.LookForTarget;
            return;
        }

        var distance = (transform.position - _target.transform.position).sqrMagnitude;
        if (distance <= _attackDistance)
        {

            _state = EnemyState.AttackTarget;
            return;
        }
    }
    private void AttackTarget()
    {
        var distance = (transform.position - _target.transform.position).magnitude;
        if (_target == null)
        {
            _damageDealer.Rest();
            _state = EnemyState.LookForTarget;
            return;
        }

        if (distance >= _attackDistance)
        {
            _damageDealer.Rest();
            _state = EnemyState.MoveToTarget;
            return;
        }
        
        _damageDealer.TryDamage(_target);
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

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }
}
