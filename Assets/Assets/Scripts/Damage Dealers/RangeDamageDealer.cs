using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDamageDealer : MonoBehaviour, IDamageDealer
{
    private Entity _entity;

    private float _attackTime;
    
    public void TryDamage(Entity target)
    {
        if (_attackTime <= 0)
        {
            _attackTime = Constants.ATTTACK_INTERVAL;
            target.ApplyDamage(_entity.Damage);
        }

        _attackTime -= Time.deltaTime * _entity.AttackSpeed;
    }
    
    public void Rest()
    {
        _attackTime = 0;
    }

    private void Awake()
    {
        _entity = GetComponent<Enemy>();
    }
}
