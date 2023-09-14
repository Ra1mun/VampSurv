using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Unit
{
    [SerializeField] private PlayerConfig _playerConfig;
    public PlayerConfig Config => _playerConfig;
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private Interaction interaction;
    public Interaction Interaction => interaction;

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