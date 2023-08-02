using UnityEngine;

public class EntityConfig : ScriptableObject
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    
    public float AttackDistance => _attackDistance;
    public float AttackSpeed => _attackSpeed;
    public int Damage => _damage;
    public int MaxHealth => _maxHealth;
    public float MoveSpeed => _moveSpeed;
}