using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitsPool : MonoBehaviour
{
    [Header("Spawners")]
    [SerializeField] private EnemySpawner _enemySpawner;

    [Header("Player")]
    [SerializeField] private Player _player;

    [Header("All Entities")]
    public static List<Unit> Units = new List<Unit>();


    public event Action<Enemy> OnEnemyKilled;
    public event Action<Player> OnPlayerKilled;
    
    private void OnEnable()
    { 
        Units.Add(_player);
        if(_player.TryGetComponent(out IHealth health)) 
            health.OnDie += DestroyUnit;
        _enemySpawner.OnEnemySpawned += OnEnemySpawned;
    }
    
    private void OnEnemySpawned(Enemy enemy)
    {
        Units.Add(enemy);
        if (enemy.TryGetComponent(out IHealth health))
            health.OnDie += DestroyUnit;
    }

    private void DestroyUnit(Unit unit)
    {
        if (unit.TryGetComponent(out IHealth health))
            health.OnDie -= DestroyUnit;
        
        unit.gameObject.Route<Player>(player => OnPlayerKilled?.Invoke(player));
        unit.gameObject.Route<Enemy>(enemy => OnEnemyKilled?.Invoke(enemy));
        
        Units.Remove(unit);
        Destroy(unit.gameObject);
    }
    
    private void OnDisable()
    {
        Units.Clear();
        _enemySpawner.OnEnemySpawned -= OnEnemySpawned;
    }
}