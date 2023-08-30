using System;
using UnityEngine;

public class LoseGameHandler : MonoBehaviour
{
    [SerializeField] private UnitsPool _pool;

    public event Action GameOver;
    
    private void OnEnable()
    {
        _pool.OnPlayerKilled += OnPlayerKilled;
    }

    private void OnPlayerKilled(Player player)
    {
        GameOver?.Invoke();
    }

    private void OnDisable()
    {
        _pool.OnPlayerKilled -= OnPlayerKilled;
    }
}
