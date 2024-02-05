using System;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class UnitHealth: MonoBehaviour, IHealth
    {
        [SerializeField] private global::Unit.Unit unit;
        [SerializeField] private UnitStats unitStats;
    
        private int MaxHealth => unitStats.GetStats().MaxHealth;
        private int _currentHealth;
    
        public event Action<int, int> OnHealthChanged;

        public event Action<global::Unit.Unit> OnDie;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                Debug.Log(MaxHealth);
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                if(_currentHealth == 0)
                    OnDie?.Invoke(unit);
            
                OnHealthChanged?.Invoke(_currentHealth, MaxHealth);
            }
        }
    }
}
