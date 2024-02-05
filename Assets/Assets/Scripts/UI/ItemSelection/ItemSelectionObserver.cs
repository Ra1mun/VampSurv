using System;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class ItemSelectionObserver : MonoBehaviour
    {
        public event Action<AssetItem> OnItemAdded; 
        
        public void AddItem(AssetItem item)
        {
            OnItemAdded?.Invoke(item);
        }
    }
}