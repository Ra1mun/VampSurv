using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Wave
{
    public class WavesSetup : MonoBehaviour
    {
        [SerializeField] private Wave _wave;
        [SerializeField] private List<WaveConfig> _waves;
        [SerializeField] private int _currentWave;
        void Awake()
        {
            _wave.OnWaveEnded += WaveEnd;
        }
        void Start()
        {
            StartNewWave();
        }
        private void WaveEnd()
        {
            StartNewWave();
        }
        private void StartNewWave()
        {
            if(_currentWave < _waves.Count)
            {
                _wave.InitializeWave(_waves[_currentWave]);
                _wave.StartWave();
                _currentWave++;
            }
        }
    }
}
