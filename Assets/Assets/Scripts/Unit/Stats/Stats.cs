using UnityEngine;

namespace Assets.Scripts.Unit.Stats
{
    public struct Stats
    {
        public int MaxHealth { get; set; }
        public float MoveSpeed { get; set; }
        public float AttackSpeed { get; set; }
        public float AttackDistance { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int ExpPerKill { get; set; }

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
                ExpPerKill = a.ExpPerKill + b.ExpPerKill,
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
                ExpPerKill = Mathf.RoundToInt(a.ExpPerKill * m),
            };
        }
    
        public static Stats Null()
        {
            return new Stats
            {
                MaxHealth = 0,
                MoveSpeed = 0,
                Damage = 0,
                AttackDistance = 0,
                AttackSpeed = 0,
                Armor = 0,
                ExpPerKill = 0
            };
        }
    }
}
