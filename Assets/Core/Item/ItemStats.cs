using Core.Stats.ConfigStats;
using Core.Stats.Decorators;
using Core.Unit;

namespace Core.Item
{
    public class ItemStats : UnitStats
    {
        public override void AddInternalStats(InternalStats internalStats)
        {
            base.AddInternalStats(internalStats);

            _provider = new InternalStatsDecorator(_provider, internalStats);
        }
    }
}