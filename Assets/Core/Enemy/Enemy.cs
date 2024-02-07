using Core.Unit;
using UnityEngine;

namespace Core.Enemy
{
    public class Enemy : Unit.Unit
    {
        [SerializeField] private EnemyStats _stats;

        public EnemyConfig Config { get; private set; }


        public void Initialize(EnemyConfig config, UnitType type)
        {
            Config = config;
            _type = type;
            _stats.Initialize(config.CommonStats);
        }
    }
}