using UnityEngine;

public class EntityFindTarget : MonoBehaviour
{
    [SerializeField] private Entity _entity;

    private int _damage => _entity.Config.Damage;
    private float _attackDistance => _entity.Config.AttackDistance;

    private IDamageDealer _damageDealer;
    
    private EnemyState _state;
    
    private Entity _target;
    
    public void OnUpdate(ITargetFinder targetFinder)
    {
        switch (_state)
        {
            case EnemyState.LookForTarget:
                LookForTarget(targetFinder);
                break;
            case EnemyState.MoveToTarget:
                MoveToTarget();
                break;
            case EnemyState.AttackTarget:
                AttackTarget();
                break;
        }
    }

    private void LookForTarget(ITargetFinder targetFinder)
    {
        _target = targetFinder.FindTarget(_entity);
        if (_target == null)
            return;

        _state = EnemyState.MoveToTarget;
    }

    private void MoveToTarget()
    {
        if (_target == null)
        {
            _state = EnemyState.LookForTarget;
            return;
        }

        var distance = (transform.position - _target.transform.position).sqrMagnitude;
        if (distance <= _attackDistance) _state = EnemyState.AttackTarget;
    }

    private void AttackTarget()
    {
        var distance = (transform.position - _target.transform.position).magnitude;
        if (_target == null)
        {
            _damageDealer.Rest();
            _state = EnemyState.LookForTarget;
            return;
        }

        if (distance >= _attackDistance)
        {
            _damageDealer.Rest();
            _state = EnemyState.MoveToTarget;
            return;
        }

        _damageDealer.TryDamage(_target.Health, _damage);
    }
}