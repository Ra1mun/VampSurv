using Core.Player.Attribute;
using Core.Unit;
using UnityEngine;

namespace Core.Item
{
    public class Item : Unit.Unit
    {
        [SerializeField] private ItemStats _stats;

        public ItemConfig Config { get; private set; }

        public ItemStats Stats => _stats;
        public AttributeType Attribute => Config.Attribute;

        public void Initialize(ItemConfig config, UnitType type)
        {
            Config = config;
            _type = type;
            _stats.Initialize(config.CommonStats);
        }
    }
}