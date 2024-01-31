using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    private List<AssetItem> _items = new List<AssetItem>();

    public event Action<AssetItem> OnItemAdded;
    public event Action<AssetItem> OnItemRemoved;

    public void AddItem(AssetItem assetItem)
    {
        _items.Add(assetItem);
        OnItemAdded?.Invoke(assetItem);
    }
    
    public void RemoveItem(AssetItem item)
    {
        if (_items.Contains(item) == false)
            return;

        _items.Remove(item);
        OnItemRemoved?.Invoke(item);
    }
}
