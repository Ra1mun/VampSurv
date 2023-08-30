using System;
using UnityEngine;

public class PlayerStats : UnitStats
{
    [SerializeField] private Player _player;
    
    public event Action<Stats> OnStatsChanged;
    
    protected override void Initialize()
    {
        Provider = new InitializeStats(_player.Config);
    }
}
