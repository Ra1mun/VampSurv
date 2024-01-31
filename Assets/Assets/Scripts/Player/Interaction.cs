using System;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteractionVisitor
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private PlayerLevel _playerLevel;

    public Action OnItemSelection;
    public void Visit(AssetItem item)
    {
        _stats.AddItemStats(item.ID);
        inventoryModel.AddItem(item);
    }
    void OnEnable()
    {
        _playerLevel.SelectItem +=OnSelectItem;
    }
    public void OnSelectItem()
    {
        OnItemSelection?.Invoke();
    }
}