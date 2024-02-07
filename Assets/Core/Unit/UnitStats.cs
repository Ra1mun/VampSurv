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
        public virtual void AddAttributeStats(AttributeStats attributeStats) { }
        public virtual void AddInternalStats(InternalStats stats) { }
        public virtual void DebuffStats(DebuffStats debuffStats) { }
    }
}