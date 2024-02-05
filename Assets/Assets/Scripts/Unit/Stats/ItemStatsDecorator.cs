using Assets.Scripts.Unit.Stats;
using UnityEngine;

namespace Assets.Scripts.Item
{
    public class ItemStatsDecorator : StatsDecorator
    {
        private readonly ItemDataBase _data;
    
        private readonly ItemID _itemID;

        public ItemStatsDecorator(IStatsProvider wrappedEntity, ItemID itemID) : base(wrappedEntity)
        {
            _itemID = itemID;
            _data = Resources.Load<ItemDataBase>("Source/ItemDataBase");
        }

        protected override Stats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + _data.GetGivenStats(_itemID);
        }
    }
}