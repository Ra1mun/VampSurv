using System;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int _maxExperience = 100;
    [SerializeField]private int _currentExperience;
    
    public Action<int, int> OnExperienceChanged;
    public Action OnLevelChanged;

    public void AddExperience(int exp)
    {
        _currentExperience += exp;
        OnExperienceChanged?.Invoke(_currentExperience, _maxExperience);
        if (_currentExperience >= _maxExperience)
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
