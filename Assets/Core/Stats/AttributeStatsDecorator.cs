using Core.Item;

namespace Core.Stats
{
    public class AttributeStatsDecorator : StatsDecorator
    {
        private readonly GivenStatsByAttribute _attributeStats;

        public AttributeStatsDecorator(IStatsProvider wrappedEntity, GivenStatsByAttribute attributeStats) : base(
            wrappedEntity)
        {
            _attributeStats = attributeStats;
        }

        protected override Stats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + _attributeStats.GetStats();
        }
    }
}