using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
// Debug Script. Delete on commit
public class InteractableModule : MonoBehaviour
{
    public ModuleConfig moduleConf;
    private TowerInventory towerInv;
    void Awake()
    {
        //moduleConf = GetComponent<ModuleConfig>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        TowerInventory.inventory.AddModule(moduleConf);
    }

    
}
