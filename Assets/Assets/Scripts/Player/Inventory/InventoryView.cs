using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryCell _inventoryCellTemplate;
    [SerializeField] private Transform _container;

    private void Start()
    {
        foreach (Transform child in _container)
            Destroy(child.gameObject);
    }

    public void RenderItem(AssetItem item)
    {
        var cell = Instantiate(_inventoryCellTemplate, _container);
        cell.Render(item);
    }
}