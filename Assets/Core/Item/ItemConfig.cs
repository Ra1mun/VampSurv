using Core.Player.Attribute;
using Core.Stats.ConfigStats;
using Core.Unit;
using UnityEngine;

namespace Core.Item
{
    [CreateAssetMenu(menuName = "Config/ItemConfig", fileName = "ItemConfig", order = 0)]
    public class ItemConfig : UnitConfig
    {
        [SerializeField] private AttributeStats _attributeStats;
        [SerializeField] private GivenStats _givenStats;
        [SerializeField] private InternalStats _internalStats;

        [Header("Attribute")] [SerializeField] private AttributeType _attribute;

        [Header("Prefab")] [SerializeField] private Item _prefab;
        public AttributeStats AttributeStats => _attributeStats;
        public GivenStats GivenStats => _givenStats;
        public InternalStats InternalStats => _internalStats;
        public Item Prefab => _prefab;
        public AttributeType Attribute => _attribute;
    }

    

}