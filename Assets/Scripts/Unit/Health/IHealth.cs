using System;
using Assets.Scripts.Unit;

public interface IHealth
{
    event Action<int, int> OnHealthChanged;
    event Action<Unit.Unit> OnDie;
}