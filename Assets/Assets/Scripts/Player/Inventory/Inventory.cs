using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    public int _inventorySize;
    private List<Item> _items = new List<Item>();
    public void ActivateItem(Item item)
    {
        var instance = Instantiate(item, transform.position, Quaternion.identity, transform);
        _items.Add(instance);
        instance.Initialize(item.Config, UnitType.Item);
    }

    public void BuffItems(AttributeType type)
    {
        _items.ForEach(item =>
        {
            if (item.Attribute == type)
            {
                item.Stats.AddAttributeStats(item.Config);
                stats.AddAttributeStats(item.Config);
            }
        });
    }
}
