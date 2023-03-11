using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _ui;

    private void OnEnable()
    {
        _player.OnHealthChanged += HealthChanged;
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= HealthChanged;
    }

    private void HealthChanged(int currentHealth, int maxHealth)
    {
        _ui.text = $"Health changed: {maxHealth}";
    }
}
