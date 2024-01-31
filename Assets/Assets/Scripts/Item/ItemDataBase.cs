using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] public ItemBase[] _items;

    [NonSerialized] private bool _isInit;

    private Dictionary<ItemID, ItemConfig> _itemStorage = new Dictionary<ItemID, ItemConfig>();
    private void Init()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _itemStorage.Add(_items[i].ID, _items[i].Item);
        }

        _isInit = true;
    }
    
    public Stats GetStats(ItemID itemID)
    {
        if (!_isInit)
        {
            Init();
        }

        if (_itemStorage.ContainsKey(itemID))
        {
            return _itemStorage[itemID].AddStats();
        }

        return Stats.NULL();
    }
   

    public Item GetItem(ItemID itemID)
    {
        if (!_isInit)
        {
            Init();
        }
        if (_itemStorage.ContainsKey(itemID))
        {
            return _itemStorage[itemID].Prefab;
        }

        return null;
    }
}

[Serializable]
public class ItemBase
{
    public ItemID ID => _itemID;
    public ItemConfig Item => _item;
    
    [SerializeField] private ItemID _itemID;
    [SerializeField] private ItemConfig _item;
}