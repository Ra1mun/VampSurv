using UnityEngine;

public abstract class UnitStats : MonoBehaviour
{
    protected IStatsProvider _provider;

    public Stats GetStats()
    {
        return _provider.GetStats();
    }
    

    public void Initialize(UnitConfig config)
    {
        _provider = new InitializeStats(config);
    }
}
