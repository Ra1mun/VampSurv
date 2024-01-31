using System;

public interface IHealth
{
    event Action<int> OnHealthChanged;
    event Action<Unit> OnDie;
}