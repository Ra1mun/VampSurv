using System;
using Assets.Scripts.Enemy;
using Assets.Scripts.Unit;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemyConfig", fileName = "EnemyConfig", order = 0)]
public class EnemyConfig : UnitConfig
{
    [SerializeField] private int _experienceOnDie;
    
    [Header("Prefab")]
    [SerializeField] private Enemy _prefab;
    
    public int ExperienceOnDie => _experienceOnDie;
    public Enemy Prefab => _prefab;
}