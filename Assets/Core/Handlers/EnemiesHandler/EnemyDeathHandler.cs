using Core.Player.Experience;
using Core.Unit;
using UnityEngine;

namespace Core.EnemiesHandler
{
    public class EnemyDeathHandler : MonoBehaviour
    {
        [SerializeField] private UnitsPool _unitsPool;
        [SerializeField] private Experience _experience;

        private void OnEnable()
        {
            _unitsPool.OnEnemyKilled += OnEnemyKilled;
        }

        private void OnDisable()
        {
            _unitsPool.OnEnemyKilled -= OnEnemyKilled;
        }

        private void OnEnemyKilled(Enemy.Enemy enemy)
        {
            _experience.AddExperience(enemy.Config.ExperienceOnDie);
        }
    }
}