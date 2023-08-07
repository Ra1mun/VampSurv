using System;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] private PlayerInteract _playerInteract;

    public PlayerInteract Interact => _playerInteract;

    private void Awake()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        _type = EntityType.Player;
    }
}