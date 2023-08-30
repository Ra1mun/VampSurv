using System;
using UnityEngine;

public class PlayerStats : EntityStats
{
    [SerializeField] private Player _player;
    
    public event Action<Stats> OnStatsChanged;
    
    
}
