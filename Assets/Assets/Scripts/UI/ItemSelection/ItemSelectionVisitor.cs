using System;
using UnityEngine;

public class ItemSelectionVisitor : MonoBehaviour, IInteractionVisitor
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private PlayerLevel _playerLevel;

    public Action OnItemSelectionEvent;
    
    private void OnEnable()
    {
        _playerLevel.OnLevelChangedEvent += OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        if (level % Constants.ITEM_SELECTION_ON_LEVEL == 0)
        {
            OnItemSelectionEvent?.Invoke();
        }
    }
    
    private void OnDisable()
    {
        _playerLevel.OnLevelChangedEvent -= OnLevelChanged;
    }
    
    public void Visit(AssetItem item)
    {
        _stats.AddItemStats(item.ID);
        inventoryModel.AddItem(item);
    }
}