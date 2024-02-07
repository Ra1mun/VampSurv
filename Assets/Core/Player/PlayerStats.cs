using Core.Item;
using Core.Stats.ConfigStats;
using Core.Stats.Decorators;
using Core.Unit;

namespace Core.Player
{
    public class PlayerStats : UnitStats
    {
        public override void AddItemStats(ItemID id)
        {
            base.AddItemStats(id);

            _provider = new ItemStatsDecorator(_provider, id);
        }

        public override void AddAttributeStats(AttributeStats attributeStats)
        {
            base.AddAttributeStats(attributeStats);

            _provider = new AttributeStatsDecorator(_provider, attributeStats);
        }
    }
}