using Assets.Scripts.Unit;
using Enemy;
using Unit;
using UnityEngine;

namespace Assets.Scripts.Enemy.Factory
{
    public abstract class EnemyFactory : ScriptableObject
    {
        public global::Enemy.Enemy Spawn(EnemyType type, Vector3 transform)
        {
            var config = GetConfig(type);
            var instance = Instantiate(config.Prefab, transform, Quaternion.identity);
            instance.Initialize(config, UnitType.Enemy);

            return instance;
        }

        protected abstract EnemyConfig GetConfig(EnemyType type);
    }
}