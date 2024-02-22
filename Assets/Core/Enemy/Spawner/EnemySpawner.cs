using System;
using System.Collections.Generic;
using Assets.Scripts.Wave;
using Core.Enemy.Factory;
using Core.Extension;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Enemy.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public event Action<Enemy> OnEnemySpawned;
        
        [SerializeField] private List<Transform> _spawnPositions;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private Transform _container;
        
        private WaveSpawnSpeed _waveSpawnSpeed;

        private void Awake()
        {
            if (_spawnPositions.Count != 0)
            {
                _waveSpawnSpeed = gameObject.AddComponent<WaveSpawnSpeedPerTime>();
                _waveSpawnSpeed.OnTimeElapsed += Spawn;
                return;
            }
            
            throw new InvalidImplementationException("Not set spawn positions!");
        }
        
        private void Spawn()
        {
            var spawnPoint = _spawnPositions.RandomItem();
            var enemy = _enemyFactory.Spawn(EnemyType.TestEnemy, spawnPoint.position, _container);

            OnEnemySpawned?.Invoke(enemy);
        }
    }
}