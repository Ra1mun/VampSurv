using UnityEngine;

public class ItemStats : EntityStats
{
    [SerializeField] private Item _item;

    protected override void Initialize()
    {
        Provider = new InitializeStats(_item.Config);
    }
}
