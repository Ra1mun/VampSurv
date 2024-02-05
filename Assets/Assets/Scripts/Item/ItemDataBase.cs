using System;
using System.Collections.Generic;
using Assets.Scripts.Unit.Stats;
using UnityEngine;

namespace Assets.Scripts.Item
{
    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
    public class ItemDataBase : ScriptableObject
    {
        [SerializeField] public DataItem[] _items;

        [NonSerialized] private bool _isInit;

        private Dictionary<ItemID, ItemConfig> _itemStorage = new Dictionary<ItemID, ItemConfig>();
    
        private void Init()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _itemStorage.Add(_items[i].ID, _items[i].ItemConfig);
            }

            _isInit = true;
        }
    
        public Stats GetGivenStats(ItemID itemID)
        {
            if (!_isInit)
            {
                Init();
            }

            if (_itemStorage.ContainsKey(itemID))
            {
                return _itemStorage[itemID].GivenStats.GetStats();
            }

            return Stats.Null();
        }
   

        public ItemConfig GetConfig(ItemID itemID)
        {
            if (!_isInit)
            {
                Init();
            }
            if (_itemStorage.ContainsKey(itemID))
            {
                return _itemStorage[itemID];
            }

            return null;
        }
    }

    [Serializable]
    public class DataItem
    {
        public ItemID ID => _itemID;
        public ItemConfig ItemConfig => _itemConfig;
    
        [SerializeField] private ItemID _itemID;
        [SerializeField] private ItemConfig _itemConfig;
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