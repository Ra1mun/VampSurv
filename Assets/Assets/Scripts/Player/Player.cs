using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Entity
{
    [SerializeField] private PlayerConfig _playerConfig;
    public PlayerConfig Config => _playerConfig;
    
    [SerializeField] private Interact interact;
    public Interact Interact => interact;

    private void Awake()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        _type = EntityType.Player;
    }
}