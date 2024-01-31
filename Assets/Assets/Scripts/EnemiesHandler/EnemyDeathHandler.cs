using System;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] private UnitsPool _unitsPool;
    [SerializeField] private Experience _experience;

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
