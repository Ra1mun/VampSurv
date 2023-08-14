using System;
using UnityEngine;
public class Item : Entity
{
    [SerializeField] private ItemMovable _itemMovable;
     
    public ItemMovable Moveable => _itemMovable;

}