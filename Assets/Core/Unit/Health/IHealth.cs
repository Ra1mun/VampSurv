using System;

namespace Core.Health
{
    public interface IHealth
    {
        event Action<int> OnHealthChanged;
        event Action<Unit.Unit> OnDie;
    }
}