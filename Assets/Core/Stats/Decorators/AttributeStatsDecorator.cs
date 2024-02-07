using Core.Stats.ConfigStats;

namespace Core.Stats.Decorators
{
    public class AttributeStatsDecorator : StatsDecorator
    {
        private readonly AttributeStats _attributeStats;

        public AttributeStatsDecorator(IStatsProvider wrappedEntity, AttributeStats attributeStats) : base(
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