using System;
using UnityEngine;

public class Enemy : Entity
{
    private EnemyConfig _enemyConfig;
    public EnemyConfig Config => _enemyConfig;
    public void Initialize(EnemyConfig config, EntityType type)
    {
        _enemyConfig = config;
        _type = type;
    }
}