using System;
using UnityEngine;

namespace Core.Item.ItemSelection
{
    public class ItemSelectionObserver : MonoBehaviour
    {
        public event Action<AssetItem.AssetItem> OnItemAdded;

        public void AddItem(AssetItem.AssetItem item)
        {
            OnItemAdded?.Invoke(item);
        }
    }
}