using System;
using Assets.Scripts.Damageable;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class UnitDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitHealth _unitHealth;

        public void ApplyDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentException(nameof(damage));

            var totalDamage = ProcessDamage(damage);
        
            _unitHealth.CurrentHealth -= totalDamage;
            Debug.Log(gameObject.name + " Takes damage: " + damage);
        }

        protected virtual int ProcessDamage(int damage)
        {
            return damage;
        }
    }
}
