using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Player _player;
    public event Action<Stats> OnStatsChanged;

    public void InteractWithItem(string itemKey)
    {
        _player.Stats.Provider = new ItemStatsDecorator(_player.Stats.Provider, itemKey);
        OnStatsChanged.Invoke(_player.Stats.GetStats());
    }
}