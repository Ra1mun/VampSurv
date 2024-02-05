using System.Collections.Generic;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Attribute;
using Assets.Scripts.Unit;
using Player;
using Unit;
using UnityEngine;

namespace Item.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private Transform container;

        private readonly List<Item> _instItems = new List<Item>();
        
        public void ActivateAndAddItem(ItemConfig itemConfig)
        {
            var instance = Instantiate(itemConfig.Prefab, transform.position, Quaternion.identity, container);
            instance.Initialize(itemConfig, UnitType.Item);
            _instItems.Add(instance);
        }

        public void AddStats(ItemID id)
        {
            stats.AddItemStats(id);
        }

        public void BuffItems(AttributeType type)
        {
            foreach (var item in _instItems)
            {
                if (item.Attribute == type)
                {
                    item.Stats.AddInternalStats(item.Config.InternalStats);
                    stats.AddAttributeStats(item.Config.AttributeStats);
                }
            }
        }
    }
}
