using System;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int MaxExperience = 100;

    private int _currentExperience;
    
    public Action OnLevelChanged;
    public Action<int> OnExperienceChanged;

    public void AddExperience(int exp)
    {
        _currentExperience += exp;
        OnExperienceChanged?.Invoke(_currentExperience);
        if (_currentExperience >= MaxExperience)
        {
            OnLevelChanged?.Invoke();
            UpLevel();
        }
    }
    
    private void UpLevel()
    {
        _currentExperience = 0;
    }
}
