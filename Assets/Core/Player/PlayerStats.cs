using Assets.Scripts.Item;
using Core.Item;
using Core.Stats;
using Core.Unit;

namespace Core.Player
{
    public class PlayerStats : UnitStats
    {
        public void AddItemStats(ItemID itemID)
        {
            _provider = new ItemStatsDecorator(_provider, itemID);
        }

        public void AddAttributeStats(AttributeStats attributeStats)
        {
            _provider = new AttributeStatsDecorator(_provider, attributeStats);
        }
    }
}