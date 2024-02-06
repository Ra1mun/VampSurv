using System;
using System.Collections.Generic;
using Core.Item;
using Core.Stats;
using UnityEngine;

namespace Assets.Scripts.Item
{
    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
    public class ItemDataBase : ScriptableObject
    {
        [SerializeField] public DataItem[] _items;

        [NonSerialized] private bool _isInit;

        private readonly Dictionary<ItemID, ItemConfig> _itemStorage = new();

        private void Init()
        {
            for (var i = 0; i < _items.Length; i++) _itemStorage.Add(_items[i].ID, _items[i].ItemConfig);

            _isInit = true;
        }

        public Stats GetGivenStats(ItemID itemID)
        {
            if (!_isInit) Init();

            if (_itemStorage.ContainsKey(itemID)) return _itemStorage[itemID].GivenStats.GetStats();

            return Stats.Null();
        }


        public ItemConfig GetConfig(ItemID itemID)
        {
            if (!_isInit) Init();
            if (_itemStorage.ContainsKey(itemID)) return _itemStorage[itemID];

            return null;
        }
    }

    [Serializable]
    public class DataItem
    {
        [SerializeField] private ItemID _itemID;
        [SerializeField] private ItemConfig _itemConfig;
        public ItemID ID => _itemID;
        public ItemConfig ItemConfig => _itemConfig;
    }

    public enum ItemID : uint
    {
        Curiass,
        Sphere,
        Spear,
        HolyWater,
        Mjolnir,
        Cross,
        Big_Cross,
        Bible,
        Censer,
        Thorn_Rune,
        GjallarHorn,
        Gleipnir,
        Zwaihander,
        Throwing_Dagger,
        Scourge,
        TorchLight
    }
}