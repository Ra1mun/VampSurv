using System;
using UnityEngine;

namespace Core.Stats.ConfigStats
{
    [Serializable]
    public class CommonStats
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _expPerKill;
        [SerializeField] private int _armor;

        public Stats GetStats()
        {
            return new Stats
            {
                AttackDistance = _attackDistance,
                MoveSpeed = _moveSpeed,
                AttackSpeed = _attackSpeed,
                Damage = _damage,
                MaxHealth = _maxHealth,
                ExpPerKill = _expPerKill,
                Armor = _armor
            };
        }
    }
}