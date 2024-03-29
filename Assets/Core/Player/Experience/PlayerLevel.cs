using System;
using UnityEngine;

namespace Core.Player.Experience
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private Experience _experience;

        private int _level;


        private void OnEnable()
        {
            _experience.OnExperienceChangedEvent += ExperienceChanged;
        }

        private void OnDisable()
        {
            _experience.OnExperienceChangedEvent -= ExperienceChanged;
        }

        public event Action<int> OnLevelChangedEvent;

        private void ExperienceChanged(int currentExperience, int maxExperience)
        {
            if (currentExperience == maxExperience)
            {
                _level++;
                OnLevelChangedEvent?.Invoke(_level);
                _experience.ResetExp();
            }
        }
    }
}