using Core.Unit;

namespace Core.Stats
{
    public class InitializeStats : IStatsProvider
    {
        private readonly CommonStats _commonStats;

        public InitializeStats(CommonStats commonStats)
        {
            _commonStats = commonStats;
        }

        public Stats GetStats()
        {
            return _commonStats.GetStats();
        }
    }
}