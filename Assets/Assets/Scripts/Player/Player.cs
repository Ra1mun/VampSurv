using System;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] private PlayerInteract _playerInteract;

    [SerializeField] private PlayerMovement _playerMovement;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _playerInteract.OnStatsChanged += ShowChages;   
    }

    private void ShowChages(Stats stats)
    {
        Debug.Log(stats.MaxHealth);
    }
    private void Initialize()
    {
        _type = EntityType.Player;
    }
}