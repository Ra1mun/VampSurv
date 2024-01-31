using UnityEngine;

public class ItemStatsDecorator : StatsDecorator
{
    private readonly ItemDataBase _data;
    
    private readonly ItemID _itemID;

    public ItemStatsDecorator(IStatsProvider wrappedEntity, ItemID itemID) : base(wrappedEntity)
    {
        _itemID = itemID;
        _data = Resources.Load<ItemDataBase>("Source/ItemDataBase");
    }

    protected override Stats GetStatsInternal()
    {
        var stats = new Stats();
        stats += _data.GetStats(_itemID);
        return _wrappedEntity.GetStats() + stats;
    }
}