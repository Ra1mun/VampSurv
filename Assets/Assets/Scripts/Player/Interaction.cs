using System;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteractionVisitor
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private InventoryModel inventoryModel;
    
    public void Visit(AssetItem item)
    {
        _stats.AddItemStats(item.ID);
        inventoryModel.AddItem(item);
    }
}