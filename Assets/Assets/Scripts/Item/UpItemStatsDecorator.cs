public class UpItemStatsDecorator : StatsDecorator
{
    public UpItemStatsDecorator(IStatsProvider wrappedEntity) 
        : base(wrappedEntity)
    {
    }

    protected override Stats GetStatsInternal()
    {
        return _wrappedEntity.GetStats() * 1.5f;
    }
}
