using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
public class ItemConfig : UnitConfig
{
    
    [Header("Change Internal Stats by step:")]
    [SerializeField] private float _stepAttackDistance;
    [SerializeField] private float _stepMoveSpeed;
    [SerializeField] private float _stepAttackSpeed;
    [SerializeField] private int _stepDamage;
    [SerializeField] private int _stepMaxHealth;
    [SerializeField] private int _stepArmor;
    [SerializeField] private int _stepExpPerKill;
    
    
    [Header("Given Stats")]
    [SerializeField] private float _addAttackDistance;
    [SerializeField] private float _addMoveSpeed;
    [SerializeField] private float _addAttackSpeed;
    [SerializeField] private int _addDamage;
    [SerializeField] private int _addMaxHealth;
    [SerializeField] private int _addExpPerKill;
    [SerializeField] private int _addArmor;

    [Header("Change Given Stats by step:")]
    [SerializeField] private float _stepAddAttackDistance;
    [SerializeField] private float _stepAddMoveSpeed;
    [SerializeField] private float _stepAddAttackSpeed;
    [SerializeField] private int _stepAddDamage;
    [SerializeField] private int _stepAddMaxHealth;
    [SerializeField] private int _stepAddExpPerKill;
    [SerializeField] private int _stepAddArmor;
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
            ExpPerKill = _addExpPerKill,
            Armor = _addArmor,
        };
    }
    public Stats ChangeInternalStatsByStep()
    {
        return new Stats
        {
            MaxHealth = _stepMaxHealth,
            MoveSpeed = _stepMoveSpeed,
            AttackDistance = _stepAttackDistance,
            AttackSpeed = _stepAttackSpeed,
            Damage = _stepDamage,
            ExpPerKill = _stepExpPerKill,
            Armor = _stepArmor,
        };
    }
    public Stats ChangeGivenStatsByStep()
    {
        return new Stats
        {
            MaxHealth = _stepAddMaxHealth,
            MoveSpeed = _stepAddMoveSpeed,
            AttackDistance = _stepAddAttackDistance,
            AttackSpeed = _stepAddAttackSpeed,
            Damage = _stepAddDamage,
            ExpPerKill = _stepAddExpPerKill,
            Armor = _stepAddArmor,
        };
    }
}
