using System;
using System.Collections.Generic;
using Core.Enemy.Spawner;
using Core.Extension;
using Core.Health;
using UnityEngine;

namespace Core.Unit
{
    public class UnitsPool : MonoBehaviour
    {
        [Header("All Entities")] public static List<Unit> Units = new();
        [Header("Spawners")] [SerializeField] private EnemySpawner _enemySpawner;

        [Header("Player")] [SerializeField] private Player.Player _player;

        private void OnEnable()
        {
            Units.Add(_player);
            if (_player.TryGetComponent(out IHealth health))
                health.OnDie += DestroyUnit;
            _enemySpawner.OnEnemySpawned += OnEnemySpawned;
        }

        private void OnDisable()
        {
            Units.Clear();
            _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
        }


        public event Action<Enemy.Enemy> OnEnemyKilled;
        public event Action<Player.Player> OnPlayerKilled;

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
    }
}