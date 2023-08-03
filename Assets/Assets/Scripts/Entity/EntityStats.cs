using UnityEngine;

public abstract class EntityStats : MonoBehaviour
{
    [SerializeField] private Entity _entity;

    public IStatsProvider Provider;

    public Stats GetStats()
    {
        return Provider.GetStats();
    }
    
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        Provider = new InitializeStats(_entity.Config);
    }
    
}
