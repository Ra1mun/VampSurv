using Assets.Scripts.Unit.Stats;

public abstract class StatsDecorator : IStatsProvider
{
    protected readonly IStatsProvider _wrappedEntity;

    protected StatsDecorator(IStatsProvider wrappedEntity)
    {
        _wrappedEntity = wrappedEntity;
    }

    public Stats GetStats()
    {
        return GetStatsInternal();
    }

    protected abstract Stats GetStatsInternal();
}