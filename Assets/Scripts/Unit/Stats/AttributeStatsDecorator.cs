using Assets.Scripts.Item;

namespace Assets.Scripts.Unit.Stats
{
    public class AttributeStatsDecorator : StatsDecorator
    {
        private readonly AttributeStats _attributeStats;

        public AttributeStatsDecorator(IStatsProvider wrappedEntity, AttributeStats attributeStats) : base(wrappedEntity)
        {
            _attributeStats = attributeStats;
        }

        protected override Stats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + _attributeStats.GetStats();
        }
    }
}
