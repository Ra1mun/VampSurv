﻿using Core.Stats.ConfigStats;

namespace Core.Stats.Decorators
{
    public class InternalStatsDecorator : StatsDecorator
    {
        private readonly InternalStatsByAttribute _internalStats;

        public InternalStatsDecorator(IStatsProvider wrappedEntity, InternalStatsByAttribute internalStats) : base(wrappedEntity)
        {
            _internalStats = internalStats;
        }

        protected override Stats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + _internalStats.GetStats();
        }
    }
}