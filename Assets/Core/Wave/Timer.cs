using Core;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        public Action TimerStart;
        public Action TimerEnd;
        private float _time;

        private float _elapsedTime;
        private bool _isStarted=false;

        private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;
        public void StartTimer(float time)
        {
            TimerStart?.Invoke();
            _time = time;
            _isStarted = true;
        }
    

        private void Update()
        {
            if(!_isStarted)
            {
                return;
            }
            if (IsPaused)
            {
                return;
            }

            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > _time)
            {
                
                _elapsedTime = 0f;
                _isStarted=false;
                TimerEnd?.Invoke();
            }
        }
    }
}
