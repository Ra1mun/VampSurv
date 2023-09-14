public class InitializeStats : IStatsProvider
{
    private readonly UnitConfig _config;

    public InitializeStats(UnitConfig config)
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
