using System;

namespace Assets.Scripts.Wave
{
    public class WaveSpawnSpeedPerTime : WaveSpawnSpeed
    {
        protected override void IncreaseSpawns()
        {
            TimeBetweenWaves *= 0.9f;
        }
    }
}