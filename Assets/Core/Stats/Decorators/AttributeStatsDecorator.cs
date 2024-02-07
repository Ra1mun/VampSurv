using Core.Stats.ConfigStats;

namespace Core.Stats.Decorators
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