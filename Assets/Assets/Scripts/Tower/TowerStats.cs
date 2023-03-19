using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerStatsData", menuName = "TowerStats/Data", order = 1)]
public class TowerStats : ScriptableObject
{
    [SerializeField]private int _maxHealth;
    [SerializeField]private int _currentHealth;
    //private EntityType _type;

    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    /*public void Initialize(int maxHealth, EntityType type)
    {
        _maxHealth = maxHealth;
        //_attackDistance = attackDistance;
        //_attackSpeed = attackSpeed;
        //_damage = damage;
        _type = type;
    }*/
    public string DebugGetStats()
    {
        string debugStats;
        debugStats = "maxHealth= "+_maxHealth + "currentHealth= " + _currentHealth;
        return debugStats;
    }
}
