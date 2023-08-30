using UnityEngine;

public abstract class EnemyFactory : ScriptableObject
{
    public Enemy Spawn(EnemyType type, Vector3 transform)
    {
        var config = GetConfig(type);
        var instance = Instantiate(config.Prefab, transform, Quaternion.identity);
        instance.Initialize(config, UnitType.Enemy);

        return instance;
    }

    protected abstract EnemyConfig GetConfig(EnemyType type);
}