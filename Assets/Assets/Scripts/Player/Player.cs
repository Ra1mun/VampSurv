using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class Player : Entity, IHealth, IDamageable
{
    [SerializeField] private Specialization spec;

    [SerializeField]
    private List<string> items = new List<string>()
    {
        "Curiass", "Sword"
    };

    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public override event Action<Entity> OnDie;

    private IDamageDealer _damageDealer;

    private float _moveSpeed;

    private PhysicsMovement _physicsMovement;

    private PlayerInteract _playerInteract;

    private IStatsProvider _provider;

    public override void OnUpdate(ITargetFinder targetFinder)
    {

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
        //_provider = new SpecializationStats(_provider, spec);

        //_provider = new ItemStatsDecorator(_provider, items);

        Debug.Log(_provider.GetStats());

        _currentHealth = _provider.GetStats().MaxHealth;

        _physicsMovement.Init(_moveSpeed);
    }
    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
        _damageDealer = GetComponent<IDamageDealer>();
    }

}

