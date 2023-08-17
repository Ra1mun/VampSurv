using System;
using Unity.VisualScripting;
using UnityEngine;

public class ExperienceHandler : MonoBehaviour
{
    [SerializeField] private PlayerExperience _player;
    [SerializeField] private GameLogic _gameLogic;
    
    private void OnEnable()
    {
        _gameLogic.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnEnemyKilled(Enemy enemy, Item item)
    {
        _player.CurrentExp += enemy.Config.ExpPerKill + item.Config.BonusExpPerKill;
    }
    
    private void OnDisable()
    {
        _gameLogic.OnEnemyKilled -= OnEnemyKilled;
    }
}
