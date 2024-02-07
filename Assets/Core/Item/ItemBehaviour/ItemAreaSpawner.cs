using Core.Item.Projectiles.ProjectilePlash;
using UnityEngine;

namespace Core.Item.ItemBehaviour
{
    public class ItemAreaSpawner : ItemBehaviour
    {
        [SerializeField] private Area area;

        protected override void SpawnSingleProjectile()
        {
            var instance = Instantiate(area, gameObject.transform);
            instance.Initialize(_itemStats.GetStats().AttackDistance,
                _itemStats.GetStats().Damage);
        }
    }
}