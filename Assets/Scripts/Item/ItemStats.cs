using Assets.Scripts.Item;
using Assets.Scripts.Unit;
using Assets.Scripts.Unit.Stats;

namespace Item
{
    public class ItemStats : UnitStats
    {
        public void AddInternalStats(InternalStats internalStats)
        {
            _provider = new InternalStatsDecorator(_provider, internalStats);
        }
    }
}
