using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
public class ItemConfig : EntityConfig
{
    [SerializeField] private string _name;

    public string Name => _name;
}
