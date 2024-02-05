using System;
using UnityEngine;

namespace Assets.Scripts.Player.Experience
{
    public class Experience : MonoBehaviour
    {
        [SerializeField] private int _maxExperience = 100;
    
        private int _currentExperience;
    
        public Action<int, int> OnExperienceChangedEvent;

        public void AddExperience(int exp)
        {
            _currentExperience += exp;
            OnExperienceChangedEvent?.Invoke(_currentExperience, _maxExperience);
        }
    
        public void Reset()
        {
            _currentExperience = 0;
        }
    }
}
