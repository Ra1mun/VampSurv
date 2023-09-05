using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Unit
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private PlayerStats _stats;
    public PlayerConfig Config => _playerConfig;

    private void Awake()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        _type = UnitType.Player;
        _stats.Initialize(_playerConfig);
    }
}