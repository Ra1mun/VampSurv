using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemyConfig", fileName = "EnemyConfig", order = 0)]
public class EnemyConfig : EntityConfig
{
    
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _expPerKill;
    public Enemy Prefab => _prefab;
    public float ExpPerKill => _expPerKill;
}