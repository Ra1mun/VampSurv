using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetItem", menuName = "Asset/Item", order = 0)]
public class AssetItem : ScriptableObject
{
    [SerializeField] private ItemID _id;
    [SerializeField] private Sprite _icon;
    
    [CanBeNull] public string Name => nameof(_id);
    public ItemID ID => _id;
    public Sprite Icon => _icon;
}