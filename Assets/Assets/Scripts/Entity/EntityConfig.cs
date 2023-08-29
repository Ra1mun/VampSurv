using UnityEngine;

public class EntityConfig : ScriptableObject
{
    [Header("Common")]
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _attackCooldown;

    public float AttackDistance => _attackDistance;
    public float AttackSpeed => _attackSpeed;
    public int Damage => _damage;
    public int MaxHealth => _maxHealth;
    public float MoveSpeed => _moveSpeed;
    public float AttackCooldown => _attackCooldown;
}