using UnityEngine;

public abstract class EntityFindTarget : MonoBehaviour
{
    public abstract void OnUpdate(ITargetFinder targetFinder);
}