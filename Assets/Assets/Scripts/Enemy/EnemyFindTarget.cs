using UnityEngine;

public class EnemyFindTarget : ITargetFinder
{
    public Unit FindTarget(Unit selfUnit)
    {
        Unit result = null;

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
