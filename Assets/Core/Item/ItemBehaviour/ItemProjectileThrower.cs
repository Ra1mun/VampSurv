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
            {
                _currentState = ItemState.AttackTarget;
            }    
            else
            {
                return;
            }
                
        }

        protected override void SpawnProjectile()
        {
            _direction = _target.gameObject.transform.position;
            var instance = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            instance.Initialize(
                _direction,
                gameObject.transform.position, _itemStats);


            _attackTime = _itemStats.GetStats().AttackSpeed; //maybe replace from this
            _currentState = ItemState.OnCooldown;
        }

        protected override void OnCooldown()
        {
            if (_attackTime <= 0)
            {
                _attackTime = _itemStats.GetStats().AttackSpeed;
                _currentState = ItemState.LookForTarget;
            }

            _attackTime -= Time.deltaTime;
        }
    }
}