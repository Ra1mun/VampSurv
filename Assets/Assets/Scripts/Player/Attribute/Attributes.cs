using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]public class AttributesDictionary : SerializableDictionary<AttributeType, int>
{ }

public class Attributes : MonoBehaviour
{
    [SerializeField] private PlayerLevel _level;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private AttributesDictionary _attributeLevels = new AttributesDictionary()
    {

        [AttributeType.Atheism] = 0,
        [AttributeType.Christianity] = 0,
        [AttributeType.Paganism] = 0,
    };

    public event Action OnLevelUp; 

    private void OnEnable()
    {
        _level.SelectAttribute += OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        OnLevelUp?.Invoke();
    }

    public void AttributeLevelUp(AttributeType type)
    {
        _attributeLevels[type]++;
        _inventory.BuffItems(type);
    }
    
    private void OnDisable()
    {
        _level.SelectAttribute -= OnLevelChanged;
    }
}
