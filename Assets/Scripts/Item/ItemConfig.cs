using System;
using Assets.Scripts.Player.Attribute;
using Assets.Scripts.Unit;
using Unit;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
    public class ItemConfig : UnitConfig
    {
        public AttributeStats AttributeStats => _attributeStats;
        public GivenStats GivenStats => _givenStats;
        public InternalStats InternalStats => _internalStats;
        public Item Prefab => _prefab;
        public AttributeType Attribute => _attribute;
    
        [SerializeField] private AttributeStats _attributeStats;
        [SerializeField] private GivenStats _givenStats;
        [SerializeField] private InternalStats _internalStats;
    
        [Header("Prefab")] 
        [SerializeField] private Item _prefab;

        [Header("Attribute")] 
        [SerializeField] private AttributeType _attribute;
    }

    [Serializable]
    public class AttributeStats : CommonStats
    {
    
    }

    [Serializable]
    public class GivenStats : CommonStats
    {
    
    }

    [Serializable]
    public class InternalStats : CommonStats
    {
    
    }
}