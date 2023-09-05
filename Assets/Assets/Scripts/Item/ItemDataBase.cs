using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private ItemConfig _curiass;
    [SerializeField] private ItemConfig _sphere;
    [SerializeField] private ItemConfig _spear;

    public Stats GetStats(ItemID itemID)
    {
        switch (itemID)
        {
            case ItemID.Curiass:
                return _curiass.AddStats();
            case ItemID.Sphere:
                return _sphere.AddStats();
            case ItemID.Spear:
                return _spear.AddStats();
            default:
                throw new NotImplementedException($"Stats {itemID} is not founded");
        }
    }
    
    public Item GetItem(ItemID itemID)
    {
        Item instance = null;
        switch (itemID)
        {
            case ItemID.Curiass:
                instance = Instantiate(_curiass.Prefab);
                instance.Initialize(_curiass, UnitType.Item);
                return instance;
            case ItemID.Sphere:
                instance = Instantiate(_sphere.Prefab);
                instance.Initialize(_spear, UnitType.Item);
                return instance;
            case ItemID.Spear:
                instance = Instantiate(_spear.Prefab);
                instance.Initialize(_spear, UnitType.Item);
                return instance;
            default:
                throw new NotImplementedException($"Prefab {itemID} is not founded");
        }
    }
}