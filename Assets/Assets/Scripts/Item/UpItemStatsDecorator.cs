using UnityEngine;
public class UpItemStatsDecorator : StatsDecorator
{
    private ItemConfig _config;
    public UpItemStatsDecorator(IStatsProvider wrappedEntity, ItemConfig config) 
        : base(wrappedEntity)
    {
        _config = config;
    }

    protected override Stats GetStatsInternal()
    {
        return _wrappedEntity.GetStats() + _config.ChangeInternalStatsByStep();
    }
}
