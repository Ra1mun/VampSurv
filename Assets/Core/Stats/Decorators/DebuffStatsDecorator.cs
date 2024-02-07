using Core.Stats;
using Core.Stats.ConfigStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Stats.Decorators
{
    public class DebuffStatsDecorator : StatsDecorator
    {
        private readonly DebuffStats _debuffStats;

        public DebuffStatsDecorator(IStatsProvider wrappedEntity, DebuffStats debuffStats) : base(wrappedEntity)
        {
            _debuffStats = debuffStats;
        }

        protected override Stats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() - _debuffStats.GetStats();
        }
    }
}
