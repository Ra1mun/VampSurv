using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlashHolyWater : ProjectilePlash
{
    private IDamageDealer _damageDealer;
    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }

    protected override void OnTargetCollision(Collider2D collision, Unit unit)
    {
        _damageDealer.TryDamage(unit, _damage);
    }
}
