using UnityEngine;
public class AssetItem : ScriptableObject
{
    [SerializeField] private ItemID _id;
    [SerializeField] private Texture2D _icon;
    [SerializeField] private ItemConfig _itemConfig;

    public ItemConfig ItemConfig => _itemConfig;
    public ItemID ID => _id;
    public Texture2D Icon => _icon;
}