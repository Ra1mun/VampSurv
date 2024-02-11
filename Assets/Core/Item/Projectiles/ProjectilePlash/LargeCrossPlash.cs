using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Item.Projectiles.ProjectilePlash
{
    public class LargeCrossPlash : Area
    {
        protected override void OnTargetCollision(Collider2D collision, Unit.Unit unit)
        {
            Debug.Log("Make damage");
            _damageDealer.TryDamage(unit, _stats.GetStats().Damage);
        }
    }
}

