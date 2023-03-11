using System;

public struct PlayerStats
{
    public int MaxHealth;
    public float AttackDistance;
    public float AttackSpeed;
    public int Damage;
    public float MoveSpeed;

    public static PlayerStats operator +(PlayerStats a, PlayerStats b)
    {
        return new PlayerStats()
        {
            MaxHealth = a.MaxHealth + b.MaxHealth,
            AttackDistance = a.AttackDistance + b.AttackDistance,
            AttackSpeed = a.AttackSpeed + b.AttackSpeed,
            Damage = a.Damage + b.Damage,
            MoveSpeed = a.MoveSpeed + b.MoveSpeed,
        };
    }
    public static PlayerStats operator *(PlayerStats a, PlayerStats b)
    {
        return new PlayerStats()
        {
            MaxHealth = a.MaxHealth * b.MaxHealth,
            AttackDistance = a.AttackDistance * b.AttackSpeed,
            AttackSpeed = a.AttackSpeed * b.AttackSpeed,
            Damage = a.Damage * b.Damage,
            MoveSpeed = a.MoveSpeed * b.MoveSpeed,
        };
    }
}
