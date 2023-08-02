using UnityEngine;

public class ItemStatsDecorator : StatsDecorator
{
    protected readonly ItemDataBase _data;

    //protected readonly IEnumerable<string> _itemKeys;
    protected readonly string _itemKey;

    public ItemStatsDecorator(IStatsProvider wrappedEntity, string itemKey) : base(wrappedEntity)
    {
        _itemKey = itemKey;
        _data = Resources.Load<ItemDataBase>("Config/ItemDataBase");
    }

    protected override PlayerStats GetStatsInternal()
    {
        var stats = new PlayerStats();
        //foreach(var item in _itemKeys)
        //{
        //    stats += _data.GetStats(item);
        //}
        stats += _data.GetStats(_itemKey);
        return _wrappedEntity.GetStats() + stats;
    }
}