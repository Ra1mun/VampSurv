using System;

public class Enemy : Entity
{
    public void Initialize(EnemyConfig config, EntityType type)
    {
        _entityConfig = config;
        _type = type;
    }
}