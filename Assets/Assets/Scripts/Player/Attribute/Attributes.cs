using System;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private Experience _experience;
    private Dictionary<AttributeType, int> _attributeLevels = new Dictionary<AttributeType, int>()
    {

        [AttributeType.Atheism] = 0,
        [AttributeType.Christianity] = 0,
        [AttributeType.Paganism] = 0,
    };

    public event Action OnUpLevel; 

    private void OnEnable()
    {
        _experience.OnLevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        OnUpLevel?.Invoke();
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
