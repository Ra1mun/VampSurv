using Assets.Scripts.Item.Projectiles.ProjectilePlash;
using UnityEngine;

namespace Assets.Scripts.Item.ItemBehaviour
{
    public class ItemAreaSpawner : ItemBehaviour
    {
        [SerializeField] Area area;

        protected override void SpawnSingleProjectile()
        {
            var instance = Instantiate(area, gameObject.transform);
            instance.Initialize(_itemStats.GetStats().AttackDistance,
                _itemStats.GetStats().Damage);

        }
    }
}
