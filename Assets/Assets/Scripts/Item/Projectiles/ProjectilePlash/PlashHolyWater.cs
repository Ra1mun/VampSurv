using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlashHolyWater : ProjectilePlash
{
    
    private void Awake()
    {
        Debug.Log("Plash Added");
    }
    protected override void OnTargetCollision(Collider2D collision, Unit unit)
    {
        _damageDealer.TryDamage(unit, _damage);
    }
    

}
