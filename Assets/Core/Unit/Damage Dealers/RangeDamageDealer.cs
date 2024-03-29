using Core.Damageable;
using UnityEngine;

namespace Core.Unit.Damage_Dealers
{
    public class RangeDamageDealer : MonoBehaviour, IDamageDealer
    {
        [SerializeField] private UnitStats _stats;
        private float _attackTime;

        public void TryDamage(Unit target, int damage)
        {
            if (_attackTime <= 0)
            {
                _attackTime = Constants.ATTTACK_INTERVAL;
                if (target.TryGetComponent(out IDamageable damageable))
                    damageable.ApplyDamage(_stats.GetStats().Damage);
            }

            _attackTime -= Time.deltaTime * _stats.GetStats().AttackSpeed;
        }

        public void Rest()
        {
            _attackTime = 0;
        }
    }
}