using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] public ItemDictionary _items;

    public Stats GetStats(ItemID itemID)
    {
        if (_items.TryGetValue(itemID, out var value))
        {
            return value.AddStats();
        }
        else
        {
            throw new NotImplementedException($"Stats {itemID} is not founded");
        }
    }
   

    public Item GetItem(ItemID itemID)
    {
        if (_items.TryGetValue(itemID, out var value))
        {
            return value.Prefab;
        }
        else
        {
            throw new NotImplementedException($"Prefab {itemID} is not founded");
        }
    }
}