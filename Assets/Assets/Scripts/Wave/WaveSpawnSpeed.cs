using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveSpawnSpeed : MonoBehaviour
{
    [SerializeField] private float _timeBetweenWaves;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _timeBetweenWaves)
        {
            IncreaseSpawns();
            _elapsedTime = 0f;
        }
    }

    protected abstract void IncreaseSpawns();
}
