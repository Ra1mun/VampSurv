using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlashHolyWater : ProjectilePlash
{
    
    private void Awake()
    {
        Debug.Log("Plash Added");
    }
    protected override void OnTargetCollision(Collider2D collision, Entity entity)
    {
        _damageDealer.TryDamage(entity, _damage);
    }
    

}
