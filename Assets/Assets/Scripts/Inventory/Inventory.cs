using System.Collections.Generic;
using Assets.Scripts.Item;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Attribute;
using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private Transform container;

        private readonly List<Item.Item> _items = new List<Item.Item>();
    
        public void AddItem(Item.Item item, ItemID id)
        {
            stats.AddItemStats(id);
            _items.Add(item);
            ActivateItem(item);
        }
    
        private void ActivateItem(Item.Item item)
        {
            var instance = Instantiate(item, transform.position, Quaternion.identity, container);
            instance.Initialize(item.Config, UnitType.Item);
        }

        public void BuffItems(AttributeType type)
        {
            foreach (var item in _items)
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
