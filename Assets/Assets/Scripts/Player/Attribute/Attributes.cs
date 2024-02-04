using System;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    
    private Dictionary<AttributeType, int> _attributeLevels = new Dictionary<AttributeType, int>()
    {
        [AttributeType.Atheism] = 0,
        [AttributeType.Christianity] = 0,
        [AttributeType.Paganism] = 0,
    };
    
    public void AttributeLevelUp(AttributeType type)
    {
        _attributeLevels[type]++;
        _inventory.BuffItems(type);
    }
}

public enum AttributeType
{
    Christianity,
    Atheism,
    Paganism
}
