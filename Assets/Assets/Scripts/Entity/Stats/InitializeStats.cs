public class InitializeStats : IStatsProvider
{
    private readonly EntityConfig _config;

    public InitializeStats(EntityConfig config)
    {
        _config = config;
    }
    
    public Stats GetStats()
    {
        return new Stats()
        {
            MoveSpeed = _config.MoveSpeed,
            Damage = _config.Damage,
            MaxHealth = _config.MaxHealth,
            AttackDistance = _config.AttackDistance,
            AttackSpeed = _config.AttackSpeed,
            AttackCooldown = _config.AttackCooldown,
        };
    }
}
