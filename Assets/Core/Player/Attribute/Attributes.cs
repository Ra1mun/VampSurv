using System.Collections.Generic;
using UnityEngine;

namespace Core.Player.Attribute
{
    public class Attributes : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory _inventory;

        private readonly Dictionary<AttributeType, int> _attributeLevels = new()
        {
            [AttributeType.Atheism] = 0,
            [AttributeType.Christianity] = 0,
            [AttributeType.Paganism] = 0
        };

        public void AttributeLevelUp(AttributeType type)
        {
            _inventory.BuffItems(type);
            _attributeLevels[type]++;
        }
    }

    public enum AttributeType
    {
        Christianity,
        Atheism,
        Paganism
    }
}