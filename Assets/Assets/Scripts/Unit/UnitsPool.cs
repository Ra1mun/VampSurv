using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy.Spawner;
using Assets.Scripts.Extension;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class UnitsPool : MonoBehaviour
    {
        [Header("Spawners")]
        [SerializeField] private EnemySpawner _enemySpawner;

        [Header("Player")]
        [SerializeField] private Player.Player _player;

        [Header("All Entities")]
        public static List<Unit> Units = new List<Unit>();


        public event Action<Enemy.Enemy> OnEnemyKilled;
        public event Action<Player.Player> OnPlayerKilled;
    
        private void OnEnable()
        { 
            Units.Add(_player);
            if(_player.TryGetComponent(out IHealth health)) 
                health.OnDie += DestroyUnit;
            _enemySpawner.OnEnemySpawned += OnEnemySpawned;
        }
    
        private void OnEnemySpawned(Enemy.Enemy enemy)
        {
            Units.Add(enemy);
            if (enemy.TryGetComponent(out IHealth health))
                health.OnDie += DestroyUnit;
        }

        private void DestroyUnit(Unit unit)
        {
            if (unit.TryGetComponent(out IHealth health))
                health.OnDie -= DestroyUnit;
        
            unit.gameObject.Route<Player.Player>(player => OnPlayerKilled?.Invoke(player));
            unit.gameObject.Route<Enemy.Enemy>(enemy => OnEnemyKilled?.Invoke(enemy));
        
            Units.Remove(unit);
            Destroy(unit.gameObject);
        }
    
        private void OnDisable()
        {
            Units.Clear();
            _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
        }
    }
}