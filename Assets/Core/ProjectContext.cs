using System;
using Core.Pause.Scripts;
using UnityEngine;

namespace Core
{
    public class ProjectContext : MonoBehaviour
    {
        public PauseManager PauseManager { get; private set; }
        
        public static ProjectContext Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
            
            Initialize();
        }

        private void Initialize()
        {
            PauseManager = new PauseManager();
        }
    }
}