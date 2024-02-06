using Core.Damageable;
using Core.Unit.Damage_Dealers;
using UnityEngine;

namespace Core.Item.Projectiles.ProjectilePlash
{
    public class PeriodicalDamageDealer : MonoBehaviour, IDamageDealer
    {
        private float _attackTime;

        public void Rest()
        {
            _attackTime = 0f;
        }

        public void TryDamage(Unit.Unit target, int damage)
        {
            if (_attackTime <= 0)
            {
                _attackTime = Constants.PERIODICAL_DAMAGE_INTERVAL;
                if (target.TryGetComponent(out IDamageable damageable)) damageable.ApplyDamage(damage);
            }

            _attackTime -= Time.deltaTime;
        }
    }
}