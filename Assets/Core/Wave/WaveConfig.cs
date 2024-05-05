using Core.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Wave
{
    [CreateAssetMenu(menuName = "Config/WaveConfig", fileName = "WaveConfig", order = 0)]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] public List<EnemyConfig> _enemyPool;
        [SerializeField] public float waveTime;
        [SerializeField] public int wavePhases;
        [SerializeField] public AnimationCurve _threatCurve;
    }
}
