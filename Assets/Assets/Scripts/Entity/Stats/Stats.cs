public struct Stats
{
    public int MaxHealth { get; set; }
    public float MoveSpeed { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackDistance { get; set; }
    public int Damage { get; set; }
    
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
            Armor = a.Armor + b.Armor
        };
    }

    public static Stats operator *(Stats a, Stats b)
    {
        return new Stats
        {
            MaxHealth = a.MaxHealth * b.MaxHealth,
            MoveSpeed = a.MoveSpeed * b.MoveSpeed,
            Damage = a.Damage * b.Damage,
            AttackDistance = a.AttackDistance * b.AttackDistance,
            AttackSpeed = a.AttackSpeed * b.AttackSpeed,
            Armor = a.Armor * b.Armor
        };
    }
}
