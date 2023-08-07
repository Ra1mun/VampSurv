using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private ItemConfig _curiass;
    [SerializeField] private ItemConfig _sphere;

    public Stats GetStats(ItemID itemID)
    {
        switch (itemID)
        {
            case ItemID.Curiass:
                return _curiass.GetStats();
            case ItemID.Sphere:
                return _sphere.GetStats();
            default:
                throw new NotImplementedException($"Stats {itemID} is not founded");
        }
    }

    public Item GetItem(ItemID itemID)
    {
        switch (itemID)
        {
            case ItemID.Curiass:
                return _curiass.Prefab;
            case ItemID.Sphere:
                return _sphere.Prefab;
            default:
                throw new NotImplementedException($"Prefab {itemID} is not founded");
        }
    }
}