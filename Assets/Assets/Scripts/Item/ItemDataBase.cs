using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Source/Data Base/ItemDataBase", order = 0)]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] private ItemConfig _testItem;
    
    public Stats GetStats(string itemKey)
    {
        switch (itemKey)
        {
            case "Curiass":
                return new Stats
                {
                    MaxHealth = _testItem.MaxHealth,
                    MoveSpeed = _testItem.MoveSpeed
                };
            default:
                throw new NotImplementedException($"Item {itemKey} is not founded");
        }
    }
}