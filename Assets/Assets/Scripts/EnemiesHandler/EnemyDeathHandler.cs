using Assets.Scripts.Player.Experience;
using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.EnemiesHandler
{
    public class EnemyDeathHandler : MonoBehaviour
    {
        [SerializeField] private UnitsPool _unitsPool;
        [SerializeField] private Experience _experience;

        private void OnEnable()
        {
            _unitsPool.OnEnemyKilled += OnEnemyKilled;
        }

        private void OnEnemyKilled(Enemy.Enemy enemy)
        {
            _experience.AddExperience(enemy.Config.ExperienceOnDie);
        }

        private void OnDisable()
        {
            _unitsPool.OnEnemyKilled -= OnEnemyKilled;
        }
    }
}
