using Assets.Scripts.Enemy;
using Assets.Scripts.Unit;
using Unit;
using UnityEngine;

namespace Enemy
{
    public class Enemy : Unit.Unit
    {
        [SerializeField] private EnemyStats _stats;
    
        private EnemyConfig _enemyConfig;
    
        public EnemyConfig Config => _enemyConfig;
    
    
        public void Initialize(EnemyConfig config, UnitType type)
        {
            _enemyConfig = config;
            _type = type;
            _stats.Initialize(config.CommonStats);
        }
    }
}