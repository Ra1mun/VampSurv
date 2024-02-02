using System;
using UnityEngine;

public abstract class UnitHealth: MonoBehaviour, IHealth
{
    [SerializeField] private Unit unit;
    [SerializeField] private UnitStats unitStats;
    
    private int _maxHealth => unitStats.GetStats().MaxHealth;
    private int _currentHealth;
    
    public event Action<int> OnHealthChanged;

    public event Action<Unit> OnDie;
    private void Start()
    {
        CurrentHealth = _maxHealth;
    }
    
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
            if(_currentHealth == 0)
                OnDie?.Invoke(unit);
            
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}
