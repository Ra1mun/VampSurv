using System.Collections.Generic;
using Assets.Scripts.Extension;
using UnityEngine;

namespace Assets.Scripts.Item.AssetItem
{
    [CreateAssetMenu(fileName = "AssetItemConfig", menuName = "Source/Asset Item Config", order = 0)]
    public class AssetItemSelectionConfig : ScriptableObject
    {
        [SerializeField] private List<AssetItem> _assetItems;

        public AssetItem GetRandomItem()
        {
            return _assetItems.RandomItem();
        }
    }
}