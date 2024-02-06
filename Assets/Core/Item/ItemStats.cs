using Core.Stats;
using Core.Unit;

namespace Core.Item
{
    public class ItemStats : UnitStats
    {
        public void AddInternalStats(InternalStats internalStats)
        {
            _provider = new InternalStatsDecorator(_provider, internalStats);
        }
    }
}