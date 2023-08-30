using System;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteractionVisitor
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private Inventory _inventory;
    
    public void Visit(AssetItem item)
    {
        _stats.Provider = new ItemStatsDecorator(_stats.Provider, item.ID);
        _inventory.AddItem(item);
    }
}