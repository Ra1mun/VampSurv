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
    [SerializeField] private List<Unit> _entities = new List<Unit>();
    [Header("Enemies")]
    [SerializeField] private  List<Enemy> _enemies = new List<Enemy>();

    public event Action<Enemy> OnEnemyKilled;
    public event Action GameOver;
    
    
    Unit ITargetFinder.FindTarget(Unit selfUnit)
    {
        Unit result = null;

        var distance = float.MaxValue;

        foreach (var e in _entities)
        {
            if (e.Type == selfUnit.Type || e.Type == UnitType.Player)
                continue;

            var tempDistance = (selfUnit.transform.position - e.transform.position).magnitude;
            if (!(tempDistance < distance)) continue;
            
            distance = tempDistance;
            result = e;
        }

        return result;
    }
    
    private void OnEnable()
    { 
        _entities.Add(_player);
        if(_player.TryGetComponent(out PlayerHealth health)) 
            health.OnDie += DestroyEntity;
        _enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }

    
    
    
    
    private void OnEnemySpawned(Enemy enemy)
    {
        _enemies.Add(enemy);
        _entities.Add(enemy);
        if (enemy.TryGetComponent(out EnemyHealth health))
            health.OnDie += DestroyEntity;
    }

    private void DestroyEntity(Unit unit)
    {
        if (unit.TryGetComponent(out UnitHealth health))
            health.OnDie -= DestroyEntity;

        if (unit.GetComponent<Player>()) 
            GameOver?.Invoke();


        if (unit.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
            OnEnemyKilled?.Invoke(enemy);
        }

        _entities.Remove(unit);
        Destroy(unit.gameObject);
    }
    
    private void OnDisable()
    {
        _entities.Clear();
        _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
    }
}