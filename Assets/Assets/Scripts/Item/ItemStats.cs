using System;
using UnityEngine;

public class ItemStats : UnitStats
{
    public void AddAttributeStats()
    {
        _provider = new UpItemStatsDecorator(_provider);
    }
}
