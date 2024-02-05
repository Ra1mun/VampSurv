using Assets.Scripts.Item;
using UnityEngine.Rendering;

namespace Assets.Scripts.Unit.Stats
{
    public class InternalStatsDecorator : StatsDecorator
    {
        private readonly InternalStats _internalStats;

        public InternalStatsDecorator(IStatsProvider wrappedEntity, InternalStats internalStats) : base(wrappedEntity)
        {
            _internalStats = internalStats;
        }

        protected override Stats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + _internalStats.GetStats();
        }
    }
}