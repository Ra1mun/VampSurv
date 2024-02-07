using System.Collections.Generic;
using Core.Item;
using Core.Player;
using Core.Player.Attribute;
using Core.Unit;
using UnityEngine;

namespace Core.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private Transform container;

        private readonly List<Item.Item> _instItems = new List<Item.Item>();

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