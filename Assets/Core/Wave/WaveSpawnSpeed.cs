using UnityEngine;

namespace Assets.Scripts.Wave
{
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
}