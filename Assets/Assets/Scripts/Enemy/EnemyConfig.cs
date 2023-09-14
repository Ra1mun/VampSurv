using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemyConfig", fileName = "EnemyConfig", order = 0)]
public class EnemyConfig : UnitConfig
{
    
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _expOnDie;
    
    public Enemy Prefab => _prefab;
    public int ExpOnDie => _expOnDie;
}