using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Transform container;

    private readonly List<Item> _items = new List<Item>();


    public void AddItem(Item item, ItemID id)
    {
        stats.AddItemStats(id);
        _items.Add(item);
        ActivateItem(item);
    }
    
    private void ActivateItem(Item item)
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
                item.Stats.AddAttributeStats(item.Config);
                stats.AddAttributeStats(item.Config);
            }
        }
    }
}
