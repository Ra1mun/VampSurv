using System;
using UnityEngine;

namespace Core.Player.Experience
{
    public class Experience : MonoBehaviour
    {
        public event Action<int, int> OnExperienceChangedEvent;

        public int MaxExperience => maxExperience;
        
        [SerializeField] private int maxExperience;
        
        private int _currentExperience;
        
        public int CurrentExperience
        {
            get => _currentExperience;
            set
            {
                _currentExperience = Mathf.Clamp(value, 0, maxExperience);
                OnExperienceChangedEvent?.Invoke(_currentExperience, maxExperience);
            }
        }

        public void ResetExp()
        {
            _currentExperience = 0;
        }
    }
}