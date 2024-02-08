using System.Collections.Generic;
using Core.Pause.Interface;
using UnityEngine;

namespace Core.Pause.Scripts
{
    public class PauseManager : IPauseHandler
    {
        [SerializeField] private List<IPauseHandler> _pauseHandlers = new List<IPauseHandler>();

        public bool IsPaused;

        public void Register(IPauseHandler pauseHandler)
        {
            if (!_pauseHandlers.Contains(pauseHandler))
            {
                _pauseHandlers.Add(pauseHandler);
            }
        }
        
        public void Unregister(IPauseHandler pauseHandler)
        {
            if (_pauseHandlers.Contains(pauseHandler))
            {
                _pauseHandlers.Remove(pauseHandler);
            }
        }
        
        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;
            for (int i = 0; i < _pauseHandlers.Count; i++)
            {
                _pauseHandlers[i].SetPaused(isPaused);
            }
        }
    }
}