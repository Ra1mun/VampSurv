using System;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private EnemyStats _stats;
    private EnemyConfig _enemyConfig;
    
    public EnemyConfig Config => _enemyConfig;
    
    
    public void Initialize(EnemyConfig config, UnitType type)
    {
        _enemyConfig = config;
        _type = type;
        _stats.Initialize(config);
    }
}