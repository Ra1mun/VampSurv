using Core.Damageable;
using Core.Unit.Damage_Dealers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Item.Projectiles.DamageDealers
{
    public class BasicDamageDealer : MonoBehaviour, IDamageDealer
    {
        public void Rest()
        {
            throw new System.NotImplementedException();
        }

        public void TryDamage(Unit.Unit target, int damage)
        {
            if (target.TryGetComponent(out IDamageable damageable))
                damageable.ApplyDamage(damage);
        }
    }
}

