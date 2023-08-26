using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
public class ItemConfig : EntityConfig
{
    [SerializeField] private int _bonusExpPerKill;
    
    [Header("Given Stats")]
    [SerializeField] private float _addAttackDistance;
    [SerializeField] private float _addMoveSpeed;
    [SerializeField] private float _addAttackSpeed;
    [SerializeField] private int _addDamage;
    [SerializeField] private int _addMaxHealth;
    

    [Header("Name")]
    [SerializeField] private string _name;

    [Header("Prefab")] [SerializeField] private AssetItem _prefab;

    public int BonusExpPerKill => _bonusExpPerKill;

    public AssetItem Prefab => _prefab;

    public Stats GetStats()
    {
        return new Stats
        {
            MaxHealth = _addMaxHealth,
            MoveSpeed = _addMoveSpeed,
            AttackDistance = _addAttackDistance,
            AttackSpeed = _addAttackSpeed,
            Damage = _addDamage,
        };
    }
}
