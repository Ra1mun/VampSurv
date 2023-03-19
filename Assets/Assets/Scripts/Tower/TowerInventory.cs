using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInventory : MonoBehaviour
{
    public List<ModuleConfig> modules = new List<ModuleConfig>(); 

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback; // делегат сменить на event

    public static TowerInventory inventory;
    private void Awake()
    {
        if (inventory == null)
        {
            inventory = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void AddModule(ModuleConfig config)
    {
        modules.Add(config);
        config.Use();
        if (onInventoryChangedCallback != null)
            onInventoryChangedCallback.Invoke();

    }

    
}
