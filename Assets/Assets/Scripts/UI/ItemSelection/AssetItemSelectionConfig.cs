using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.ItemSelection
{
    public class AssetItemSelectionConfig : ScriptableObject
    {
        [SerializeField] private List<AssetItem> _assetItems;

        public AssetItem GetRandomItem()
        {
            return _assetItems.RandomItem();
        }
    }
}