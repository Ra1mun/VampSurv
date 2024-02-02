using System;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private PlayerLevel _level;
    [SerializeField] private Inventory _inventory;

    public event Action OnAttributeLevelChangedEvent; 
    
    private Dictionary<AttributeType, int> _attributeLevels = new Dictionary<AttributeType, int>()
    {
        [AttributeType.Atheism] = 0,
        [AttributeType.Christianity] = 0,
        [AttributeType.Paganism] = 0,
    };

    private void OnEnable()
    {
        _level.OnLevelChangedEvent += OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        if (level % Constants.ITEM_SELECTION_ON_LEVEL != 0)
        {
            OnAttributeLevelChangedEvent?.Invoke();
        }
    }

    private void OnDisable()
    {
        _level.OnLevelChangedEvent -= OnLevelChanged;
    }
    
    public void AttributeLevelUp(AttributeType type)
    {
        _attributeLevels[type]++;
        _inventory.BuffItems(type);
    }
}
