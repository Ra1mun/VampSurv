using Assets.Scripts.Wave;
using Core.Enemy.Factory;
using Core.Extension;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Core.Enemy.Spawner
{
    [RequireComponent(typeof(Assets.Scripts.Timer))]

    public class PhaseEnemySpawner : MonoBehaviour, ISpawner
    {
        public event Action<Enemy> OnEnemySpawned;

        [SerializeField] private List<Transform> _spawnPositions;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private Transform _container;
        [SerializeField] private List<EnemyConfig> _enemyToSpawn;
        [SerializeField] private Wave _wave;
        private Assets.Scripts.Timer _spawnTimer;

        [SerializeField]private float _timeBetweemSpawn;
        private void Awake()
        {
            if (_spawnPositions.Count != 0)
            {
                _spawnTimer = gameObject.GetComponent<Assets.Scripts.Timer>();
                _spawnTimer.TimerStart += Spawn;    
                _spawnTimer.TimerEnd += Spawned;
                _wave.OnPhaseStart += PhaseStarted;
                return;
            }

            throw new InvalidImplementationException("Not set spawn positions!");
        }
        private void PhaseStarted()
        {
            _enemyToSpawn = _wave._enemyPool.EnemyPool;
            if (_enemyToSpawn == null)
            {
                _spawnTimer.StartTimer(2f);
                return;
            }
            _timeBetweemSpawn =  _wave._timeBetweenPhases / _enemyToSpawn.Count;
            _spawnTimer.StartTimer(_timeBetweemSpawn);
            

        }
        private void Spawned()
        {
            Debug.Log("Spawned");
            if (_enemyToSpawn.Count > 0)
            {
                _spawnTimer.StartTimer(_timeBetweemSpawn);
                Debug.Log("startTimer");
            }
            else
            {
                _wave.PhaseEnd();
                Debug.Log("Phase End");
            }
            
                
        }
        private void Spawn()
        {
            var spawnPoint = _spawnPositions.RandomItem();
            var enemy = _enemyFactory.Spawn(_enemyToSpawn[0], spawnPoint.position, _container);
            _enemyToSpawn.RemoveAt(0);
            
            OnEnemySpawned?.Invoke(enemy);
        }
    }
}
