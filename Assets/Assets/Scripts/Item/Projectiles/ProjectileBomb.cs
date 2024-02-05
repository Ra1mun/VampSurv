using Assets.Scripts.Item.Projectiles.ProjectilePlash;
using UnityEngine;

namespace Assets.Scripts.Item.Projectiles
{
    public class ProjectileBomb : Projectile
    {
        [SerializeField] private Area _plash;
        protected override void OnProjectileDispose()
        {
            var instance = Instantiate(_plash,gameObject.transform.position, Quaternion.identity);
            instance.Initialize(_radius, _damage);
        }
    }
}
