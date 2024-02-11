using Core.Item.Projectiles;
using Core.Item.Projectiles.ProjectilePlash;
using Core.Item.TargetFinder;
using Core.Unit;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Core.Item.ItemBehaviour
{
    public class ItemLargeCross : ItemBehaviour
    {
        [SerializeField] private Area _area;
        [SerializeField] private ItemNearestTargetFinder _targetFinder;
        private Enemy.Enemy _target;
        private float _attackTime;
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
            var instance = Instantiate(_area, _target.gameObject.transform.position, Quaternion.identity);
            instance.Initialize(_itemStats);

            _attackTime = _itemStats.GetStats().AttackSpeed; 
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
