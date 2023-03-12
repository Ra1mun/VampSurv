using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
[RequireComponent(typeof(PlayerInteract))]
public class Player : Entity, IHealth, IDamageable
{
    //[SerializeField] private Specialization spec;

    //[SerializeField] private Dictionary<ItemType, string> _items
    //    = new Dictionary<ItemType, string>()
    //    {
    //        [ItemType.Weapon] = "Bow",
    //        [ItemType.Chest] = "Curiass"
    //    };
    private IStatsProvider _provider;

    private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public override event Action<Entity> OnDie;

    private IDamageDealer _damageDealer;
    
    private float _moveSpeed;
    
    private PhysicsMovement _physicsMovement;

    private PlayerInteract _playerInteract;

    private void GetDefualtStats()
    {
        _provider = new DefualtStats();
    }

    private void GetItemStats(string itemKey)
    {
        _provider = new ItemStatsDecorator(_provider, itemKey);
    }

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
            _playerInteract.OnInteracted -= GetItemStats;
        }
    }

    private void Start()
    {
        GetDefualtStats();
        _playerInteract.OnInteracted += GetItemStats;
        _currentHealth = _provider.GetStats().MaxHealth;
        _physicsMovement.Init(_provider.GetStats().MoveSpeed);
    }

    private void Awake()
    {
        _playerInteract = GetComponent<PlayerInteract>();
        _physicsMovement = GetComponent<PhysicsMovement>();
        _damageDealer = GetComponent<IDamageDealer>();
    }
    private void OnDisable()
    {
        _playerInteract.OnInteracted -= GetItemStats;
    }
}
