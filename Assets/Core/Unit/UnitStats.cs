using Core.Item;
using Core.Stats;
using Core.Stats.ConfigStats;
using UnityEngine;

namespace Core.Unit
{
    public abstract class UnitStats : MonoBehaviour
    {
        protected IStatsProvider _provider;

        public void Initialize(CommonStats commonStats)
        {
            _provider = new InitializeStats(commonStats);
        }

        public Stats.Stats GetStats()
        {
            return _provider.GetStats();
        }

        public virtual void AddItemStats(ItemID id) { }
        public virtual void AddAttributeStats(GivenStatsByAttribute attributeStats) { }
        public virtual void AddInternalStats(InternalStatsByAttribute stats) { }
        public virtual void DebuffStats(DebuffStats debuffStats) { }
    }
}