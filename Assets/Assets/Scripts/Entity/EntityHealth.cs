using System;
using UnityEngine;

public abstract class EntityHealth: MonoBehaviour, IHealth
{
    [SerializeField] private Entity _entity;
    [SerializeField] private EntityStats _entityStats;
    
    private int _currentHealth;
    
    private int _maxHealth => _entityStats.Provider.GetStats().MaxHealth;
    
    public event Action<int> OnHealthChanged;

    public event Action<Entity> OnDie;

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
            if(_currentHealth == 0)
                OnDie?.Invoke(_entity);
            
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
    
}
