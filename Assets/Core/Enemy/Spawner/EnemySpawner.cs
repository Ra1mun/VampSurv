using System;
using System.Collections.Generic;
using Assets.Scripts.Wave;
using Core.Enemy.Factory;
using Core.Extension;
using UnityEngine;
using Assets.Scripts;
using Unity.VisualScripting;

namespace Core.Enemy.Spawner
{
    public abstract class EnemySpawner : MonoBehaviour, ISpawner
    {
        
        [SerializeField] private List<Transform> _spawnPositions;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private Transform _container;

        private Assets.Scripts.Timer _spawnTimer;

        public event Action<Enemy> OnEnemySpawned;

        private void Awake()
        {
            if (_spawnPositions.Count != 0)
            {
                _spawnTimer = gameObject.AddComponent<Assets.Scripts.Timer>();
                _spawnTimer.TimerEnd += Spawn;
                return;
            }
            
            throw new InvalidImplementationException("Not set spawn positions!");
        }
        
        public virtual void Spawn()
        {
            var spawnPoint = _spawnPositions.RandomItem();
            var enemy = _enemyFactory.Spawn(EnemyType.TestEnemy, spawnPoint.position, _container);
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}