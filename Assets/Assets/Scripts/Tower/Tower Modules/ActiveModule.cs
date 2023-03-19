using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Module", menuName = "Tower Modules/OffensiveModule", order = 1)]
public class ActiveModule : ModuleConfig
{
    public override void Use()
    {
        Instantiate(_modulePref,Tower.instance.transform);
        Debug.Log("Module Activated");
    }
}
