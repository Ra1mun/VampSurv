using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class UnitFindTarget : MonoBehaviour, ITargetFinder
    {
        public abstract Unit FindTarget(Unit selfUnit);
    }
}
