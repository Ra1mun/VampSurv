using System;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemDataBase", menuName = "Configuration/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    public PlayerStats GetStats(string itemKey)
    {
        switch (itemKey)
        {
            case "Curiass":
                return new PlayerStats()
                {
                    MaxHealth = 20,
                    MoveSpeed = -5,
                };
            case "Sword":
                return new PlayerStats()
                {
                    AttackSpeed = 10,
                    Damage = 15,
                };
            case "Bow":
                return new PlayerStats()
                {
                    AttackDistance = 24,
                    Damage = 15,
                };
            default:
                throw new NotImplementedException($"Item {itemKey} is not founded");
        }
    }
}
