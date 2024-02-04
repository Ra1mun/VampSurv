using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int InventorySize = 6;
    
    [SerializeField] private PlayerStats stats;
    
    private readonly List<Item> _items = new List<Item>();


    public void AddItem(Item item)
    {
        stats.AddItemStats();
        _items.Add(item);
        ActivateItem(item);
    }
    
    private void ActivateItem(Item item)
    {
        var instance = Instantiate(item, transform.position, Quaternion.identity, transform);
        instance.Initialize(item.Config, UnitType.Item);
    }

    public void BuffItems(AttributeType type)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Attribute == type)
            {
                _items[i].Stats.AddAttributeStats(_items[i].Config);
                stats.AddAttributeStats(_items[i].Config);
            }
        }
    }
}
