using System;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerStats : UnitStats
{
    public event Action<Stats> OnStatsChanged;

    public void AddItemStats(ItemID itemID)
    {
        _provider = new ItemStatsDecorator(_provider, itemID);
        OnStatsChanged?.Invoke(_provider.GetStats());
    }
    
    public void AddAttributeStats(ItemConfig itemConfig)
    {
        _provider = new AttributeStatsDecorator(_provider, itemConfig);
    }
}
