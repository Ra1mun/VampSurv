using System;
using Core;
using UnityEngine;

namespace Assets.Scripts.Wave
{
    public abstract class WaveSpawnSpeed : MonoBehaviour
    {
        public event Action OnTimeElapsed;
        
        private float _elapsedTime;

        protected float TimeBetweenWaves = 2f;
        
        private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;
        
        private void Update()
        {
            if (IsPaused)
            {
                return;
            }
            
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > TimeBetweenWaves)
            {
                OnTimeElapsed?.Invoke();
                IncreaseSpawns();
                _elapsedTime = 0f;
            }
        }

        protected abstract void IncreaseSpawns();
    }
}