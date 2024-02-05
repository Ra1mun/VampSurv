using Assets.Scripts.Item;
using Assets.Scripts.Unit;
using Assets.Scripts.Unit.Stats;
using Item;

namespace Player
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
