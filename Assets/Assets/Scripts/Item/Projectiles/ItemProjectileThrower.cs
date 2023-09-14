using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ItemNearestTargetFinder))]
public class ItemProjectileThrower : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private ItemStats _itemStats;
    [SerializeField] private ItemNearestTargetFinder _targetFinder;

    private float _cooldownDuration => _itemStats.GetStats().AttackCooldown; //must be deleted from this, stats and etc.
    private float _attackSpeed => _itemStats.GetStats().AttackSpeed;

    private float _attackTime;

    private Enemy _target;
    private Vector2 _direction;
    private ItemState _state = ItemState.LookForTarget;
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
        _target = _targetFinder.LookForTarget(_itemStats.GetStats().AttackDistance);
        if (_target != null)
            _state = ItemState.AttackTarget;
        else
            return;
    }
    public void SpawnProjectile()
    {
        _direction = _target.gameObject.transform.position;
        var instance = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        instance.Initialize(_itemStats.GetStats().MoveSpeed,
            _itemStats.GetStats().AttackDistance,
            _itemStats.GetStats().Damage,
            _direction,
            gameObject.transform.position);


        _attackTime = _cooldownDuration; //maybe replace from this
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

    private void OnDrawGizmos()
    {
        Vector3 parent = gameObject.transform.position;
        Vector2 p = new Vector2(parent.x, parent.y);

        Gizmos.DrawLine(gameObject.transform.position, ((_direction - p).normalized) + p);
    }
}
