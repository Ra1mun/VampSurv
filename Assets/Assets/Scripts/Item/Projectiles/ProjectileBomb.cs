using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBomb : Projectile
{
    [SerializeField] private ProjectilePlash _plash;
    protected override void OnProjectileDispose()
    {
        var instance = Instantiate(_plash,gameObject.transform.position, Quaternion.identity);
        instance.Initialize(_speed, _radius, _damage);
    }
}
