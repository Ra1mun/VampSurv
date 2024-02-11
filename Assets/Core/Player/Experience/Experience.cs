using System;
using UnityEngine;

namespace Core.Player.Experience
{
    public class Experience : MonoBehaviour
    {
        public event Action<int, int> OnExperienceChangedEvent;

        [SerializeField] private int maxExperience;
        private int _currentExperience = 0;
        
        public int MaxExperience
        {
            get => maxExperience;
            private set { maxExperience = value; }
        }

        public int CurrentExperience
        {
            get => _currentExperience;
            set
            {
                _currentExperience = Mathf.Clamp(value, 0, maxExperience);
                OnExperienceChangedEvent?.Invoke(_currentExperience, MaxExperience);
            }
        }
    }
}