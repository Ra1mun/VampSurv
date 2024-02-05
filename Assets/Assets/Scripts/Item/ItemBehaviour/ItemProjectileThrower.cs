using Assets.Scripts.Item.Projectiles;
using Assets.Scripts.Item.TargetFinder;
using UnityEngine;

namespace Assets.Scripts.Item.ItemBehaviour
{
    [RequireComponent(typeof(ItemNearestTargetFinder))]
    public class ItemProjectileThrower : ItemBehaviour
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private ItemNearestTargetFinder _targetFinder;

        private float _attackSpeed => _itemStats.GetStats().AttackSpeed;

        private float _attackTime;

        private Enemy.Enemy _target;
        private Vector2 _direction;
    
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

        private void OnDrawGizmos()
        {
            Vector3 parent = gameObject.transform.position;
            Vector2 p = new Vector2(parent.x, parent.y);

            Gizmos.DrawLine(gameObject.transform.position, ((_direction - p).normalized) + p);
        }
    }
}
