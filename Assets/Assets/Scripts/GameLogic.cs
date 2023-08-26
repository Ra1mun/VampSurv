using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour, ITargetFinder
{
    [Header("Spawners")]
    [SerializeField] private EnemySpawner _enemySpawner;

    [Header("Player")]
    [SerializeField] private Player _player;

    [Header("All Entities")]
    [SerializeField] private List<Entity> _entities = new List<Entity>();
    [Header("Enemies")]
    [SerializeField] private  List<Enemy> _enemies = new List<Enemy>();

    public event Action<Enemy> OnEnemyKilled;
    public event Action GameOver;
    

    private void OnEnable()
    {
        _entities.Add(_player);
        _enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }

    private void Update()
    {
        _enemySpawner.OnUpdate();
        _enemies.ForEach(enemy =>
        {
            enemy.FindTarget.OnUpdate(this);
        });
    }
    
    Entity ITargetFinder.FindTarget(Entity selfEntity)
    {
        Entity result = null;

        var distance = float.MaxValue;

        foreach (var e in _entities)
        {
            if (e.Type == selfEntity.Type || e.Type == EntityType.Player)
                continue;

            var tempDistance = (selfEntity.transform.position - e.transform.position).magnitude;
            if (tempDistance < distance)
            {
                distance = tempDistance;
                result = e;
            }
        }

        return result;
    }
    
    private void OnEnemySpawned(Enemy enemy)
    {
        _enemies.Add(enemy);
        _entities.Add(enemy);
        enemy.Health.OnDie += DestroyEntity;
    }

    private void DestroyEntity(Entity entity)
    {
        entity.Health.OnDie -= DestroyEntity;
        _entities.Remove(entity);
        if (entity.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }

        Destroy(entity.gameObject);
    }
    
    private void OnDisable()
    {
        _entities.Clear();
        _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
    }
}