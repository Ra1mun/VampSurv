using UnityEngine;

namespace Assets.Scripts.Item.TargetFinder
{
    public class ItemNearestTargetFinder : MonoBehaviour
    {
        private Enemy.Enemy _target;

        public Enemy.Enemy LookForTarget(float radius)
        {
            _target = null;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            float distance = float.MaxValue;
            foreach (Collider2D coll in colliders)
            {
                if (coll.gameObject.TryGetComponent(out Enemy.Enemy tar))
                {
                    var tempDistance = (coll.transform.position - gameObject.transform.position).magnitude;
                    if (tempDistance < distance)
                    {
                        distance = tempDistance;
                        _target = tar;
                    }
                }
            }
            return _target;
        }

    }
}
