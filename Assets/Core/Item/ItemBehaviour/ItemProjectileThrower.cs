using Core.Item.Projectiles;
using Core.Item.TargetFinder;
using UnityEngine;

namespace Core.Item.ItemBehaviour
{
    [RequireComponent(typeof(ItemNearestTargetFinder))]
    public class ItemProjectileThrower : ItemBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private ItemNearestTargetFinder _targetFinder;

        private float _attackTime;
        private Vector2 _direction;

        private Enemy.Enemy _target;

        private float _attackSpeed => _itemStats.GetStats().AttackSpeed;

        private void OnDrawGizmos()
        {
            var parent = gameObject.transform.position;
            var p = new Vector2(parent.x, parent.y);

            Gizmos.DrawLine(gameObject.transform.position, (_direction - p).normalized + p);
        }

        protected override void LookForTarget()
        {
            _target = _targetFinder.LookForTarget(_itemStats.GetStats().AttackDistance);
            if (_target != null)
                _currentState = ItemState.AttackTarget;
            else
                return;
        }

        protected override void SpawnProjectile()
        {
            _direction = _target.gameObject.transform.position;
            var instance = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            instance.Initialize(_itemStats.GetStats().MoveSpeed,
                _itemStats.GetStats().AttackDistance,
                _itemStats.GetStats().Damage,
                _direction,
                gameObject.transform.position);


            _attackTime = _attackSpeed; //maybe replace from this
            _currentState = ItemState.OnCooldown;
        }

        protected override void OnCooldown()
        {
            if (_attackTime <= 0)
            {
                _attackTime = _attackSpeed;
                _currentState = ItemState.LookForTarget;
            }

            _attackTime -= Time.deltaTime;
        }
    }
}