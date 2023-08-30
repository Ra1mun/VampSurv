using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    public IStatsProvider Provider;
    
    public Stats GetStats()
    {
        return Provider.GetStats();
    }
    
    

    public void Initialize(EntityConfig config)
    {
        Provider = new InitializeStats(config);
    }

}
