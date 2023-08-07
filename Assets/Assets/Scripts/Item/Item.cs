using System;
using UnityEngine;
public class Item : Entity
{
    [SerializeField] private ItemMoveable _itemMoveable;

    public ItemMoveable Moveable => _itemMoveable;
    
    
}