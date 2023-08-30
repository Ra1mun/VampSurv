using UnityEngine;

public abstract class UnitStats : MonoBehaviour
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

    protected abstract void Initialize();

}
