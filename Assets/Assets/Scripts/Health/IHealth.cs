using System;
using Assets.Scripts.Unit;

public interface IHealth
{
    event Action<int> OnHealthChanged;
    event Action<Unit> OnDie;
}