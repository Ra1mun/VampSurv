using Core.Item.Projectiles.ProjectilePlash;
using UnityEngine;

namespace Core.Item.Projectiles
{
    public class ProjectileBomb : Projectile
    {
        [SerializeField] private Area _prefabPlash;

        protected override void OnProjectileDispose()
        {
            Area instance;
            if(_projectileContainer != null)
            {
                instance = Instantiate(_prefabPlash, gameObject.transform.position, Quaternion.identity, _projectileContainer);
            }
            else
            {
                instance = Instantiate(_prefabPlash, gameObject.transform.position, Quaternion.identity);
            }

            instance.Initialize(_radius, _damage);
        }
    }
}