using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private RectTransform _container;

    private readonly Dictionary<AssetItem, InventoryCell> _initCells = new Dictionary<AssetItem, InventoryCell>();

    public void RenderItem(AssetItem item)
    {
        var cell = Instantiate(_inventoryCellTemplate, _container);
        cell.Render(item);
        _initCells.Add(item, cell);
    }
    
}