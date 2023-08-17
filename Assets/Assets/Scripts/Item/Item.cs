using System;
using UnityEngine;
public class Item : Entity
{
    private ItemConfig _itemConfig;
    public ItemConfig Config => _itemConfig;
    
    [SerializeField] private ItemMovable _itemMovable;
    public ItemMovable Moveable => _itemMovable;

    public void Initialize(ItemConfig itemConfig)
    {
        _itemConfig = itemConfig;
    }
}