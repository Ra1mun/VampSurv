using System;
using UnityEngine;

public class ItemStats : UnitStats
{

    public void AddAttributeStats(ItemConfig config)
    {
        _provider = new UpItemStatsDecorator(_provider, config);
    }
}
