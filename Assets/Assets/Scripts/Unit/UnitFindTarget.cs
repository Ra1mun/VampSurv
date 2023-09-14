using UnityEngine;

public abstract class UnitFindTarget : MonoBehaviour, ITargetFinder
{
    public abstract Unit FindTarget(Unit selfUnit);
}
