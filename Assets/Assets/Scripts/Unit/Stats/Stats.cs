using UnityEngine;

public struct Stats
{
    public int MaxHealth { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackDistance { get; set; }
    public int Damage { get; set; }
    public float AttackCooldown { get;set; }
    public int Armor { get; set; }

    public static Stats operator +(Stats a, Stats b)
    {
        return new Stats
        {
            MaxHealth = a.MaxHealth + b.MaxHealth,
            MoveSpeed = a.MoveSpeed + b.MoveSpeed,
            Damage = a.Damage + b.Damage,
            AttackDistance = a.AttackDistance + b.AttackDistance,
            AttackSpeed = a.AttackSpeed + b.AttackSpeed,
            Armor = a.Armor + b.Armor,
            AttackCooldown = a.AttackCooldown + b.AttackCooldown
        };
    }

    public static Stats operator *(Stats a, float m)
    {
        return new Stats
        {
            MaxHealth = Mathf.RoundToInt(a.MaxHealth * m),
            MoveSpeed = a.MoveSpeed * m,
            Damage = Mathf.RoundToInt(a.Damage * m),
            AttackDistance = a.AttackDistance * m,
            AttackSpeed = a.AttackSpeed * m,
            Armor = Mathf.RoundToInt(a.Armor * m),
            AttackCooldown = a.AttackCooldown * m,
        };
    }
}
