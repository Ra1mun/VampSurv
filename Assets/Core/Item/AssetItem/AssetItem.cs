using Assets.Scripts.Item;
using UnityEngine;

namespace Core.Item.AssetItem
{
    [CreateAssetMenu(fileName = "AssetItem", menuName = "Asset/Item", order = 0)]
    public class AssetItem : ScriptableObject
    {
        [SerializeField] private ItemID _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;

        public ItemID ID => _id;
        public Sprite Icon => _icon;
        public string Name => _name;
    }
}