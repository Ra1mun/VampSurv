using System;
using UnityEngine;

public class PlayerLevelObserver : MonoBehaviour
{
    [SerializeField] private PlayerLevel _playerLevel;

    public event Action OnItemSelectionEvent;
    public event Action OnAttributeSelectionEvent;
    
    private void OnEnable()
    {
        _playerLevel.OnLevelChangedEvent += OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        if (level % Constants.ITEM_SELECTION_ON_LEVEL == 0)
        {
            OnItemSelectionEvent?.Invoke();
        }
        else
        {
            OnAttributeSelectionEvent?.Invoke();
        }
    }
    
    private void OnDisable()
    {
        _playerLevel.OnLevelChangedEvent -= OnLevelChanged;
    }
}