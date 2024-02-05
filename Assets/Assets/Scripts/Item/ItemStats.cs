using Assets.Scripts.Unit;
using Assets.Scripts.Unit.Stats;
using UnityEngine;

namespace Assets.Scripts.Item
{
    public class ItemStats : UnitStats
    {
        public void AddInternalStats(InternalStats internalStats)
        {
            _provider = new InternalStatsDecorator(_provider, internalStats);
        }
    }
}
