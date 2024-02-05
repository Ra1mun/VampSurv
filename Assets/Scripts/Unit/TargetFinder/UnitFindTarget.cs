using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class UnitFindTarget : MonoBehaviour, ITargetFinder
    {
        public abstract global::Unit.Unit FindTarget(global::Unit.Unit selfUnit);
    }
}
