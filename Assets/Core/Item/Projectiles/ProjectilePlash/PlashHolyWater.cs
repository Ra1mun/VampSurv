using UnityEngine;

namespace Core.Item.Projectiles.ProjectilePlash
{
    public class PlashHolyWater : Area
    {
        private void Awake()
        {
            Debug.Log("Plash Added");
        }

        protected override void OnTargetCollision(Collider2D collision, Unit.Unit unit)
        {
            _damageDealer.TryDamage(unit, _damage);
        }
    }
}