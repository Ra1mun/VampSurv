using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Wave
{
    public class Wave : MonoBehaviour
    {
        private WaveConfig _waveConfig;
        public Action WaveEnded;
        [SerializeField] public float _timeBetweenPhases;
        [SerializeField] private int _currentPhase;

        public WaveEnemyPool _enemyPool;
        //public float TimeBetweenPhases => _timeBetweenPhases;

        public Action OnWaveStart;
        public Action OnWaveEnded;
        public Action OnPhaseEnded;
        public Action OnPhaseStart;

        public void InitializeWave(WaveConfig waveConfig)
        {
            _waveConfig = waveConfig;
            _timeBetweenPhases = _waveConfig.waveTime / _waveConfig.wavePhases;
            _currentPhase = 1;
        }

        public void StartWave()
        {

            MakePhase();
            OnWaveStart?.Invoke();
        }
        public void PhaseEnd()
        {
            OnPhaseEnded?.Invoke();
            _currentPhase++;
            if (_currentPhase >= _waveConfig.wavePhases)
                return;
            MakePhase();
        }
        void PhaseStart()
        {
            Debug.Log("new Phase");
            OnPhaseStart?.Invoke();
        }
        private void MakePhase()
        {
            int threat = (int)_waveConfig._threatCurve.Evaluate(_currentPhase);
            _enemyPool = new WaveEnemyPool(threat, _waveConfig._enemyPool);
            _enemyPool.MakePool();
            PhaseStart();
        }


    }
}