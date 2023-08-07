using UnityEngine;

public abstract class EntityTargetFinder : MonoBehaviour
{
    public abstract void OnUpdate(ITargetFinder targetFinder);
}