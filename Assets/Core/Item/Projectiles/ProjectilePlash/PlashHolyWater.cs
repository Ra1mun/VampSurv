using UnityEngine;

namespace Core.Item.Projectiles.ProjectilePlash
{
    public class PlashHolyWater : Area
    {
        public bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

        private void Awake()
        {
            Debug.Log("Plash Added");
        }

        protected override void OnTargetCollision(Collider2D collision, Unit.Unit unit)
        {
            if (IsPaused)
            {
                return;
            }

            _damageDealer.TryDamage(unit, _damage);
        }
    }
}