using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    public int _inventorySize;
    private List<Item> _items = new List<Item>();


    public void AddItem(Item item)
    {
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
