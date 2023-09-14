using UnityEngine;

public abstract class UnitStats : MonoBehaviour
{
    public IStatsProvider Provider;
    
    public Stats GetStats()
    {
        return Provider.GetStats();
    }
    
    

    public void Initialize(UnitConfig config)
    {
        Provider = new InitializeStats(config);
    }

}
