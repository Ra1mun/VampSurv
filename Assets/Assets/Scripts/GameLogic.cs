using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour, ITargetFinder
{
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private Player _player;

    private readonly List<Entity> _entities = new List<Entity>();

    private void Awake()
    {
        _enemySpawner.OnEnemySpawned += OnEntitySpawned;
    }

    private void Update()
    {
        foreach (var entity in _entities)
        {
            if(entity.FindTarget != null)
                entity.FindTarget.OnUpdate(this);
        }
    }

    private void OnDestroy()
    {
        _enemySpawner.OnEnemySpawned -= OnEntitySpawned;
    }

    Entity ITargetFinder.FindTarget(Entity entity)
    {
        Entity result = null;

        var distance = float.MaxValue;

        foreach (var e in _entities)
        {
            if (e.Type == entity.Type || e.Type == EntityType.Player)
                continue;

            var tempDistance = (entity.transform.position - e.transform.position).magnitude;
            if (tempDistance < distance)
            {
                distance = tempDistance;
                result = e;
            }
        }

        return result;
    }

    private void OnEntitySpawned(Entity entity)
    {
        if(entity.Health == null)
            return;
        
        entity.Health.OnDie += DestroyEntity;
        _entities.Add(entity);
    }

    private void DestroyEntity(Entity entity)
    {
        entity.Health.OnDie -= DestroyEntity;
        _entities.Remove(entity);
        Destroy(entity.gameObject);
    }
}