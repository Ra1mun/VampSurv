using System;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private EnemyFindTarget _enemyFindTarget;
    private EnemyConfig _enemyConfig;

    public EnemyFindTarget FindTarget => _enemyFindTarget;
    public EnemyConfig Config => _enemyConfig;
    
    
    public void Initialize(EnemyConfig config, EntityType type)
    {
        _enemyConfig = config;
        _type = type;
    }
}