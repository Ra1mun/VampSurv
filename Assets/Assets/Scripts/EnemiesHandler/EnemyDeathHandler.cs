using System;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] private readonly UnitsPool _unitsPool;
    [SerializeField] private readonly Experience _experience;

    private void OnEnable()
    {
        _unitsPool.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        _experience.AddExperience(enemy.Config.ExperienceOnDie);
    }

    private void OnDisable()
    {
        _unitsPool.OnEnemyKilled -= OnEnemyKilled;
    }
}
