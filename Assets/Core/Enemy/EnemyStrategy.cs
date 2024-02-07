using Core.Unit;
using Core.Unit.Damage_Dealers;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Enemy
{
    public class EnemyStrategy : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyStats _stats;
        [SerializeField] private UnitMoveable _moveable;
        private IDamageDealer _damageDealer;
        private ITargetFinder _findTarget;
        private EnemyState _state;
        private Unit.Unit _target;
        private float _attackDistance => _stats.GetStats().AttackDistance;

        private void Awake()
        {
            _findTarget = new EnemyFindTarget();
            gameObject.TryGetComponent(out _damageDealer);
        }

        private void Update()
        {
            switch (_state)
            {
                case EnemyState.LookForTarget:
                    LookForTarget();
                    break;
                case EnemyState.MoveToTarget:
                    MoveToTarget();
                    break;
                case EnemyState.AttackTarget:
                    AttackTarget();
                    break;
                default:
                    throw new InvalidImplementationException($"State: {_state} not found!");
            }
        }

        private void LookForTarget()
        {
            _target = _findTarget.FindTarget(_enemy);
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

            _moveable.Move(_target.transform.position);
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

            _damageDealer.TryDamage(_target, _stats.GetStats().Damage);
        }

        private enum EnemyState
        {
            LookForTarget,
            MoveToTarget,
            AttackTarget
        }
    }
}