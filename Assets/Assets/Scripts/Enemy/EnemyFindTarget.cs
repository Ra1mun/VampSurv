public class EnemyFindTarget : ITargetFinder
{
    public Unit FindTarget(Unit selfUnit)
    {
        Unit result = null;

        var distance = float.MaxValue;

        foreach (var unit in UnitsPool.Units)
        {
            if (unit.Type == selfUnit.Type || unit.Type == UnitType.Player)
                continue;

            var tempDistance = (selfUnit.transform.position - unit.transform.position).magnitude;
            if (!(tempDistance < distance)) continue;
            
            distance = tempDistance;
            result = unit;
        }

        return result;
    }
}
