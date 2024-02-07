using Core.Unit;
using Core.Stats.ConfigStats;
using Core.Stats.Decorators;

namespace Core.Item
{
    public class ItemStats : UnitStats
    {
        public override void AddInternalStats(InternalStatsByAttribute internalStats)
        {
            _provider = new InternalStatsDecorator(_provider, internalStats);
        }
    }
}