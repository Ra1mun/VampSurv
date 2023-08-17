using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ItemOverlapTargetFinder))]
public class ProjectileLinearThrower : MonoBehaviour
{
    [SerializeField] private ProjectileLinear projectile;
    [SerializeField] private Item _item;
    [SerializeField] private ItemOverlapTargetFinder _targetFinder;

    private float _cooldownDuration => _item.Stats.GetStats().AttackCooldown; //must be deleted from this, stats and etc.
    private float _attackSpeed => _item.Stats.GetStats().AttackSpeed;

    private float _attackTime;

    private Enemy _target;
    private Vector2 _direction;
    private ItemState _state= ItemState.LookForTarget;
    private void Update()
    {
        switch (_state)
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
    private void LookForTarget()
    {
        _target = _targetFinder.LookForTarget(_item.Stats.GetStats().AttackDistance);
        if (_target != null)
            _state = ItemState.AttackTarget;
        else
            return;
    }
    public void SpawnProjectile()
    {
        _direction = _target.gameObject.transform.position;
        var instance = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        instance.Initialize(_item.Stats.GetStats().MoveSpeed,
            _item.Stats.GetStats().AttackDistance,
            _item.Stats.GetStats().Damage,
            _direction);
        _state = ItemState.OnCooldown;
    }
    private void OnCooldown()
    {
        if (_attackTime <= 0)
        {
            _attackTime = _cooldownDuration;
            _state = ItemState.LookForTarget;    
        }
        _attackTime -= Time.deltaTime;
    }
}
