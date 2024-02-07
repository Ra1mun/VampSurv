using System;
using Core.Stats.ConfigStats;
using Core.Player.Attribute;
using Core.Unit;
using UnityEngine;

namespace Core.Item
{
    [CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
    public class ItemConfig : UnitConfig
    {
        [SerializeField] private InternalStatsByAttribute _internalStatsByAttribute;
        [SerializeField] private GivenStats _givenStats;
        [SerializeField] private GivenStatsByAttribute _givenStatsByAttribute;
        

        [Header("Attribute")] [SerializeField] private AttributeType _attribute;

        [Header("Prefab")] [SerializeField] private Item _prefab;

        public InternalStatsByAttribute InternalStats => _internalStatsByAttribute;
        public GivenStats GivenStats => _givenStats;
        public GivenStatsByAttribute AttributeStats => _givenStatsByAttribute;
        
        public Item Prefab => _prefab;
        public AttributeType Attribute => _attribute;
    }

    
}