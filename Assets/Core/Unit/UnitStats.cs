using Core.Stats;
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
    }
}