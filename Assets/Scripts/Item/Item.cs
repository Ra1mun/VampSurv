using Assets.Scripts.Player.Attribute;
using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Item
{
    public class Item : Unit.Unit
    {
        [SerializeField] private ItemStats _stats;
    
        private ItemConfig _itemConfig;
    
        public ItemConfig Config => _itemConfig;
        public ItemStats Stats => _stats;
        public AttributeType Attribute => _itemConfig.Attribute;
    
        public void Initialize(ItemConfig config, UnitType type)
        {
            _itemConfig = config;
            _type = type;
            _stats.Initialize(config.CommonStats);
        }
    }
}
