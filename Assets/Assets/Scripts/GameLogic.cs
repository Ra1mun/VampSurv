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

    [Header("ItemDataBase")] 
    [SerializeField] private ItemDataBase _data;
    
    
    [Header("All Entities")]
    [SerializeField] private List<Entity> _entities = new List<Entity>();
    [Header("Enemies")]
    [SerializeField] private  List<Enemy> _enemies = new List<Enemy>();
    [Header("Items")]
    [SerializeField] private List<Item> _items = new List<Item>();
    
    public event Action<Enemy, Item> OnEnemyKilled;
    public event Action GameOver;
    

    private void OnEnable()
    {
        _entities.Add(_player);
        _enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }

    private void Update()
    {
        _enemySpawner.OnUpdate();
        
        // foreach (var enemy in _enemies)
        // {
        //     enemy.Update.OnUpdate(this);
        // }
        //
        // foreach (var item in _items)
        // {
        //     if(item.Update != null)
        //         item.Update.OnUpdate(this);
        // }
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

    private void OnEnemySpawned(Enemy enemy)
    {
        _enemies.Add(enemy);
        _entities.Add(enemy);
        enemy.Health.OnDie += DestroyEntity;
        
    }

    public void OnItemInteracted(ItemID itemID)
    {
        var instance = _data.GetItem(itemID);
        Instantiate(instance, _player.transform);
        _items.Add(instance);
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
        _entities.Remove(_player);
        _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
    }
}