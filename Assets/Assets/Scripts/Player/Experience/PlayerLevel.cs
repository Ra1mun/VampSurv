using System;
using UnityEngine;

namespace Assets.Scripts.Player.Experience
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private Experience _experience;
    
        private int _level;
    
        public event Action<int> OnLevelChangedEvent;
    

        private void OnEnable()
        {
            _experience.OnExperienceChangedEvent += ExperienceChanged;
        }

        private void ExperienceChanged(int currentExperience, int maxExperience)
        {
            if (currentExperience >= maxExperience)
            {
                LevelUp();
                _experience.Reset();
            }
        }

        private void LevelUp()
        {
            _level++;
            OnLevelChangedEvent?.Invoke(_level);
        }

        private void OnDisable()
        {
            _experience.OnExperienceChangedEvent -= ExperienceChanged;
        }
    }
}
