using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    public IStatsProvider Provider;

    public Stats GetStats()
    {
        return Provider.GetStats();
    }
    
    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        Provider = new InitializeStats(null);
    }
    
}