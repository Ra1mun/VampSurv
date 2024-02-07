using UnityEngine;

namespace Core.Item.TargetFinder
{
    public class ItemNearestTargetFinder : MonoBehaviour
    {
        private Enemy.Enemy _target;

        public Enemy.Enemy LookForTarget(float radius)
        {
            _target = null;
            var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            var distance = float.MaxValue;
            foreach (var coll in colliders)
                if (coll.gameObject.TryGetComponent(out Enemy.Enemy tar))
                {
                    var tempDistance = (coll.transform.position - gameObject.transform.position).magnitude;
                    if (tempDistance < distance)
                    {
                        distance = tempDistance;
                        _target = tar;
                    }
                }

            return _target;
        }
    }
}