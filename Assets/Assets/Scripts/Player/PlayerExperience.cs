using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private int _maxExp;

    private float _currentExp;
    
    public Action OnLevelChanged;
    public Action<float> OnExpChanged;
    
    public float CurrentExp
    {
        get => _currentExp;
        set
        {
            _currentExp = Mathf.Clamp(value, 0, _maxExp);
            if (_currentExp >= _maxExp)
            {
                OnLevelChanged?.Invoke();
                RestExp();
            }
            
            OnExpChanged?.Invoke(_currentExp);
        }
    }
    
    private void RestExp()
    {
        _currentExp = 0;
    }
}
