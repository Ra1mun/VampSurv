using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public TowerStats stats;

    public delegate void OnStatusChangedCallback();
    public OnStatusChangedCallback onStatusChangedCallback;

    public static StatsManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void IncreaseTowerStats(ModuleConfig newModule)
    {
        if(newModule.type == ModuleType.statsModule)
        {
            stats.CurrentHealth = CurrentHealthCalc(stats.MaxHealth, stats.MaxHealth + newModule.MaxHealth,
                stats.CurrentHealth);
            stats.MaxHealth += newModule.MaxHealth;
            onStatusChangedCallback?.Invoke();
            Debug.Log(stats.DebugGetStats());
        }
    }
    private int CurrentHealthCalc(int oldMaxHealth, int curMaxHealth, int curHealth)
    {
        float percent;
        percent = curHealth / oldMaxHealth;
        curHealth = (int)(curMaxHealth*percent);
        return curHealth;
    }
}
