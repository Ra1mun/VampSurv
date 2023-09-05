using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
public class ItemConfig : UnitConfig
{
    [Header("Given Stats")]
    [SerializeField] private float _addAttackDistance;
    [SerializeField] private float _addMoveSpeed;
    [SerializeField] private float _addAttackSpeed;
    [SerializeField] private int _addDamage;
    [SerializeField] private int _addMaxHealth;
    
    
    [Header("Prefab")] 
    [SerializeField] private Item _prefab;

    [Header("Attribute")] 
    [SerializeField] private AttributeType _attribute;
    
    public Item Prefab => _prefab;
    public AttributeType Attribute => _attribute;

    public Stats AddStats()
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
