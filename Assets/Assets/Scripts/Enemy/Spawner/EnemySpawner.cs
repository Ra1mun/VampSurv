using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private EnemySpawnerState _state;
    [SerializeField] private EnemyFactory _enemyFactory;
    private float _delayBeforeSpawn;
    private float _elapsedTime;
    
    public event Action<Enemy> OnEnemySpawned;
    
    private void Awake()
    {
        if (_spawnPositions.Count != 0) return;
        
        _state = EnemySpawnerState.None;
        throw new InvalidImplementationException("Not set spawn positions!");
    }

    private void Update()
    {
        switch (_state)
        {
            case EnemySpawnerState.Start:
                SingleSpawn();
                break;
            case EnemySpawnerState.Update:
                UpdateSpawn();
                break;
            case EnemySpawnerState.None:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void UpdateSpawn()
    {
        if (_elapsedTime > _delayBeforeSpawn)
        {
            Spawn();
            _elapsedTime = 0f;
        }

        _elapsedTime += Time.deltaTime;
    }

    private void SingleSpawn()
    {
        if (FindObjectOfType<Enemy>() == false)
            Spawn();
    }

    private void Spawn()
    {
        var spawnPoint = _spawnPositions.RandomItem();
        var enemy = _enemyFactory.Spawn(EnemyType.TestEnemy, spawnPoint.position);

        OnEnemySpawned?.Invoke(enemy);
    }
}