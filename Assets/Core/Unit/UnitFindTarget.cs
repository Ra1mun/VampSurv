using UnityEngine;

namespace Core.Unit
{
    public abstract class UnitFindTarget : MonoBehaviour, ITargetFinder
    {
        public abstract Unit FindTarget(Unit selfUnit);
    }
}