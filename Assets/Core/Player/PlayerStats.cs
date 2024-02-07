using Core.Item;
using Core.Stats.Decorators;
using Core.Unit;
using Core.Stats.ConfigStats;

namespace Core.Player
{
    public class PlayerStats : UnitStats
    {
        public override void AddItemStats(ItemID itemID)
        {
            _provider = new ItemStatsDecorator(_provider, itemID);
        }

        public override void AddAttributeStats(GivenStatsByAttribute attributeStats)
        {
            _provider = new AttributeStatsDecorator(_provider, attributeStats);
        }
    }
}