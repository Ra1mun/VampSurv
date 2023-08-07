using System;
using UnityEngine;

public abstract class EntityHealth: MonoBehaviour, IHealth
{
    [SerializeField] private Entity _entity;
    
    private int _currentHealth;
    
    [SerializeField] private int _maxHealth => _entity.Stats.Provider.GetStats().MaxHealth;
    
    public event Action<int> OnMaxHealthChanged;
    public event Action<int> OnHealthChanged;

    public event Action<Entity> OnDie;
    
    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _currentHealth = value;
            OnMaxHealthChanged?.Invoke(_maxHealth);
        }
    }

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            if(_currentHealth == 0)
                OnDie?.Invoke(_entity);
            
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
    
}
