using System;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private EnemyFindTarget _enemyFindTarget;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private EnemyStats _enemyStats;
    public EnemyFindTarget FindTarget => _enemyFindTarget;
    public EnemyConfig Config => _enemyConfig;
    
    
    public void Initialize(EnemyConfig config, EntityType type)
    {
        _enemyConfig = config;
        _type = type;
        _enemyStats.Initialize(config);
    }
}