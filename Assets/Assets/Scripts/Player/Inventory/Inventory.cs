using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> _items = new List<Item>();
    public void ActivateItem(Item item)
    {
        var instance = Instantiate(item, transform.position, Quaternion.identity, transform);
        _items.Add(instance);
    }

    public void BuffItems(AttributeType type)
    {
        _items.ForEach(item =>
        {
            if(item.Attribute == type) item.Stats.AddAttributeStats();
        });
    }
}
