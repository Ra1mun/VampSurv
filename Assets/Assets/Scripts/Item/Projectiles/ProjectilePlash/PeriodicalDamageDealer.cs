using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicalDamageDealer : MonoBehaviour, IDamageDealer
{
    private float _attackTime = 0f;
    
    public void Rest()
    {
        _attackTime = 0f;
    }

    public void TryDamage(Entity target, int damage)
    {
        if (_attackTime <= 0)
        {
            
            _attackTime = Constants.PERIODICAL_DAMAGE_INTERVAL;
            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(damage);
            }
        }
        
        _attackTime -= Time.deltaTime;
    }
}
