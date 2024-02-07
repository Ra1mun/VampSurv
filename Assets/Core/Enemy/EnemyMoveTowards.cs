using Core.Unit;
using UnityEngine;

namespace Core.Enemy
{
    public class EnemyMoveTowards : UnitMoveable
    {
        [SerializeField] private EnemyStats _stats;

        private float _speed => _stats.GetStats().MoveSpeed;

        public override void Move(Vector2 direction)
        {
            transform.position = Vector2.MoveTowards(transform.position, direction, _speed * Time.deltaTime);
        }
    }
}