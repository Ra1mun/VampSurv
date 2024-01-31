using UnityEngine;

public class Item : Unit
{
    [SerializeField] private ItemStats _stats;
    
    [SerializeField]private ItemConfig _itemConfig;
    public ItemConfig Config => _itemConfig;
    public ItemStats Stats => _stats;
    public AttributeType Attribute => _itemConfig.Attribute;
    public void Initialize(ItemConfig config, UnitType type)
    {
        _itemConfig = config;
        _type = type;
        _stats.Initialize(config);
    }
}
