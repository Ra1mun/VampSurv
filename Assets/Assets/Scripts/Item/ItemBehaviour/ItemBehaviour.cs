using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBehaviour : MonoBehaviour
{
    [Header("Behaviour Options")]
    [SerializeField] protected ItemState _StartState;
    [SerializeField] protected bool _isSingleProjectile;
    [Header("Dependency")]
    [SerializeField] protected ItemStats _itemStats;

    protected ItemState _currentState;
    private void Start()
    {
        _currentState = _StartState;
        if (_isSingleProjectile)
            SpawnSingleProjectile();
    }
    private void Update()
    {
        StateMachine();
    }
    protected virtual void StateMachine()
    {
        switch (_currentState)
        {
            case ItemState.LookForTarget:
                LookForTarget();
                break;
            case ItemState.AttackTarget:
                SpawnProjectile();
                break;
            case ItemState.OnCooldown:
                OnCooldown();
                break;
        }
    }
    protected virtual void LookForTarget()
    {
        
    }
    protected virtual void SpawnProjectile()
    {

    }
    protected virtual void SpawnSingleProjectile()
    {

    }
    protected virtual void OnCooldown()
    {
        
    }
}
