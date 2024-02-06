using Core.Item.Projectiles.ProjectilePlash;
using UnityEngine;

namespace Core.Item.Projectiles
{
    public class ProjectileBomb : Projectile
    {
        [SerializeField] private Area _plash;

        protected override void OnProjectileDispose()
        {
            var instance = Instantiate(_plash, gameObject.transform.position, Quaternion.identity);
            instance.Initialize(_radius, _damage);
        }
    }
}