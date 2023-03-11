using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefualtStats : IStatsProvider
{
    public PlayerStats GetStats()
    {
        return new PlayerStats()
        {
            AttackDistance = 5,
            AttackSpeed = 10,
            Damage = 5,
            MaxHealth = 100,
            MoveSpeed = 10,
        };
    }
}
