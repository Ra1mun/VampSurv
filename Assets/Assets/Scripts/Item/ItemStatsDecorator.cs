using UnityEngine;

public class ItemStatsDecorator : StatsDecorator
{
    protected readonly ItemDataBase _data;

    //protected readonly IEnumerable<string> _itemKeys;
    protected readonly string _itemKey;

    public ItemStatsDecorator(IStatsProvider wrappedEntity, string itemKey) : base(wrappedEntity)
    {
        _itemKey = itemKey;
        _data = Resources.Load<ItemDataBase>("Source/ItemDataBase");
    }

    protected override Stats GetStatsInternal()
    {
        var stats = new Stats();
        stats += _data.GetStats(_itemKey);
        return _wrappedEntity.GetStats() + stats;
    }
}