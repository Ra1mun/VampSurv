using System;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<AssetItem> _items = new List<AssetItem>();

    public event Action<AssetItem> OnItemAdded;
    public event Action<AssetItem> OnItemRemoved;

    public void AddItem(AssetItem assetItem)
    {
        Debug.Log(assetItem.Name);
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
    
    public void ActivateItem(Item item)
    {
        var instance = Instantiate(item, _player.gameObject.transform);
    }
}
