using UnityEngine;
public class AttributeStatsDecorator : StatsDecorator
{
    private ItemConfig _config; 

    public AttributeStatsDecorator(IStatsProvider wrappedEntity, ItemConfig config) : base(wrappedEntity)
    {
        _config = config;
    }

    protected override Stats GetStatsInternal()
    {
        var stats = new Stats();
        stats += _config.ChangeGivenStatsByStep();
        return _wrappedEntity.GetStats() + stats;
    }
}
