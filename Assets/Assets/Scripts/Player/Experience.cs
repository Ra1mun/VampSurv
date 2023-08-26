using System;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public int MaxExp { get; private set; } = 100;

    private int _currentExp;
    
    public Action OnLevelChanged;
    public Action<int> OnExpChanged;

    public void AddExp(int exp)
    {
        _currentExp += exp;
        OnExpChanged?.Invoke(_currentExp);
        if (_currentExp >= MaxExp)
        {
            OnLevelChanged?.Invoke();
        }
    }
    
    public void UpLvl()
    {
        _currentExp = 0;
    }
}
