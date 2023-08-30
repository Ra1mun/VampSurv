using UnityEngine;

public class Item : Entity
{
    [SerializeField] private ItemConfig _itemConfig;
    [SerializeField] private ItemStats _itemStats;
    public ItemConfig Config => _itemConfig;
    private void Awake()
    {
        _itemStats.Initialize(_itemConfig);
    }
}
