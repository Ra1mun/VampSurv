using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPositions;

    [SerializeField] private EnemyFactory _enemyFactory;

    [SerializeField] private float _delayBeforeSpawn;

    [SerializeField] private EnemySpawnerState _state;
    
    public event Action<Enemy> OnEnemySpawned;

    private float _elapsedTime;

    private void Start()
    {
        if (_spawnPositions.Count == 0) _spawnPositions.Add(Vector3.zero);
    }

    public void OnUpdate()
    {
        switch (_state)
        {
            case EnemySpawnerState.Start:
                Single();
                break;
            case EnemySpawnerState.Update:
                SpawnUpdate();
                break;
        }
    }

    

    private void SpawnUpdate()
    {
        if (_elapsedTime > _delayBeforeSpawn)
        {
            Spawn();
            _elapsedTime = 0f;
        }

        _elapsedTime += Time.deltaTime;
    }

    private void Single()
    {
        if (FindObjectOfType<Enemy>() == false)
            Spawn();
    }

    private void Spawn()
    {
        var spawnPosition = _spawnPositions.RandomItem();
        var enemy = _enemyFactory.Spawn(EnemyType.TestEnemy, spawnPosition);

        OnEnemySpawned?.Invoke(enemy);
    }
}