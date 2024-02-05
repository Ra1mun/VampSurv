using Assets.Scripts.Unit;

namespace Assets.Scripts.Enemy
{
    public class EnemyFindTarget : ITargetFinder
    {
        public global::Assets.Scripts.Unit.Unit FindTarget(global::Assets.Scripts.Unit.Unit selfUnit)
        {
            global::Assets.Scripts.Unit.Unit result = null;

            var distance = float.MaxValue;

            foreach (var unit in UnitsPool.Units)
            {
                if (unit.Type == UnitType.Player)
                {
                    var tempDistance = (selfUnit.transform.position - unit.transform.position).magnitude;
                    if ((tempDistance < distance))
                    {
                        distance = tempDistance;
                        result = unit;
                    }
                }

            
            }

            return result;
        }
    }
}
