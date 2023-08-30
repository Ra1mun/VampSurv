using System;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] private readonly GameLogic _gameLogic;
    [SerializeField] private readonly Experience _experience;

    private void OnEnable()
    {
        _gameLogic.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        _experience.AddExperience(enemy.Config.ExpOnDie);
    }

    private void OnDisable()
    {
        _gameLogic.OnEnemyKilled -= OnEnemyKilled;
    }
}
