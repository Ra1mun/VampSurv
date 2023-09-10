using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlashHolyWater : ProjectilePlash
{
    [SerializeField] private OverTimeDamageDealer _damageDealer;
    private void Awake()
    {
        Debug.Log("Plash Added");
    }
    protected override void OnTargetCollision(Collider2D collision, EntityDamageable damageable)
    {
        _damageDealer.AddEntity(damageable);
    }
    protected override void OnTargetCollisionExit(Collider2D collision, EntityDamageable damageable)
    {
        _damageDealer.RemoveEntity(damageable);
    }

}
