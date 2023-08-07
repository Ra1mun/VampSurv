using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityConfig _entityConfig;
    public EntityConfig Config => _entityConfig;

    [SerializeField] protected EntityHealth _entityHealth;
    [SerializeField] protected EntityTargetFinder EntityTargetFinder;
    [SerializeField] protected EntityDamagable _entityDamagable;
    [SerializeField] protected EntityStats _entityStats;
    
    public EntityHealth Health => _entityHealth;
    public EntityDamagable Damagable => _entityDamagable;
    public EntityTargetFinder TargetFinder => EntityTargetFinder;
    public EntityStats Stats => _entityStats;
    
    protected EntityType _type;
    public EntityType Type => _type;
}
