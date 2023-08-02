using System;
using UnityEngine;

public class EntityHealth: MonoBehaviour, IHealth
{
    [SerializeField] private Entity _entity;
    
    private int _currentHealth;

    private int _maxHealth => _entity.Config.MaxHealth;
    
    public event Action<int, int> OnHealthChanged;

    public event Action<Entity> OnDie;
        
    private void Awake()
    {
        _entity = GetComponent<Enemy>();
    }
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    private bool IsAlive()
    {
        return _currentHealth > 0;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_maxHealth, _currentHealth);

        if (!IsAlive()) OnDie?.Invoke(_entity);
    }
}
