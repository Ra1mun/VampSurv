using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Module", menuName = "Tower Modules/StatsModules", order = 1)]
public class StatsModule : ModuleConfig
{
    public override void Use()
    {
        StatsManager.instance.IncreaseTowerStats(this);
    }
}
