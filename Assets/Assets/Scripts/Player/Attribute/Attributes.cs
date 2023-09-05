using System;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private Experience _experience;
    [SerializeField] private InventoryModel inventoryModel;
    private Dictionary<AttributeType, int> _attributeLevels = new Dictionary<AttributeType, int>()
    {

        [AttributeType.Atheism] = 0,
        [AttributeType.Christianity] = 0,
        [AttributeType.Paganism] = 0,
    };

    public event Action OnLevelUp; 

    private void OnEnable()
    {
        _experience.OnLevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        OnLevelUp?.Invoke();
    }

    public void AttributeLevelUp(AttributeType type)
    {
        _attributeLevels[type]++;
        
    }
    
    private void OnDisable()
    {
        _experience.OnLevelChanged -= OnLevelChanged;
    }
}
