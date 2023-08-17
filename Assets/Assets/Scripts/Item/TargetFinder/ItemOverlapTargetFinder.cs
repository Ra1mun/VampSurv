using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ItemOverlapTargetFinder : MonoBehaviour
{
    private Enemy _target;

    public Enemy LookForTarget(float radius)
    {
        _target = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        float distance = float.MaxValue;
        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject.TryGetComponent(out Enemy tar))
            {
                var tempDistance = (collider.transform.position - gameObject.transform.position).magnitude;
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
