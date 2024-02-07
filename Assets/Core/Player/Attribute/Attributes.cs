using System.Collections.Generic;
using UnityEngine;

namespace Core.Player.Attribute
{
    public class Attributes : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory inventory;

        public readonly Dictionary<AttributeType, int> AttributeLevels = new()
        {
            [AttributeType.Atheism] = 0,
            [AttributeType.Christianity] = 0,
            [AttributeType.Paganism] = 0
        };

        public void AttributeLevelUp(AttributeType type)
        {
            inventory.BuffItems(type);
            AttributeLevels[type]++;
        }
    }

    public enum AttributeType
    {
        Christianity,
        Atheism,
        Paganism
    }
}