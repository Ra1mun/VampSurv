using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBomb : Projectile
{
    [SerializeField] private Area _plash;
    protected override void OnProjectileDispose()
    {
        var instance = Instantiate(_plash,gameObject.transform.position, Quaternion.identity);
        instance.Initialize(_radius, _damage);
    }
}
