using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityConfig _entityConfig;
    public EntityConfig Config => _entityConfig;

    private EntityHealth _entityHealth;

    private EntityFindTarget _entityFindTarget;

    public EntityHealth Health => _entityHealth;

    public EntityFindTarget FindTarget => _entityFindTarget;

    protected EntityType _type;
    public EntityType Type => _type;

    private void Awake()
    {
        _entityHealth = GetComponent<EntityHealth>();
        _entityFindTarget = GetComponent<EntityFindTarget>();
    }
}
