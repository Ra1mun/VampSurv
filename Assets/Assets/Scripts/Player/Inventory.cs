using System;
using System.Collections.Generic;

public class Inventory
{
    private List<AssetItem> _items = new List<AssetItem>();

    public event Action OnItemAdded;

    public void AddItem(AssetItem assetItem)
    {
        _items.Add(assetItem);
        
    }
}
