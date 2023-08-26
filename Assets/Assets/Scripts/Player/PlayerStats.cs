using System;
using UnityEngine;

public class PlayerStats : EntityStats
{
    [SerializeField] private Player _player;
    
    protected override void Initialize()
    {
        Provider = new InitializeStats(_player.Config);
    }
}
