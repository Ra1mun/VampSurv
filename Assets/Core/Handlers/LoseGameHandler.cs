using System;
using Core.Unit;
using UnityEngine;

namespace Core.Handlers
{
    public class LoseGameHandler : MonoBehaviour
    {
        [SerializeField] private UnitsPool _pool;

        private void OnEnable()
        {
            _pool.OnPlayerKilled += OnPlayerKilled;
        }

        private void OnDisable()
        {
            _pool.OnPlayerKilled -= OnPlayerKilled;
        }

        public event Action GameOver;

        private void OnPlayerKilled(Player.Player player)
        {
            GameOver?.Invoke();
        }
    }
}