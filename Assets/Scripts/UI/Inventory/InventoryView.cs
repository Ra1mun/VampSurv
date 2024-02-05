using System.Collections.Generic;
using Assets.Scripts.Inventory;
using Assets.Scripts.Item.AssetItem;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryCell _inventoryCellTemplate;
        [SerializeField] private RectTransform _container;

        private readonly Dictionary<AssetItem, InventoryCell> _initCells = new Dictionary<AssetItem, InventoryCell>();

        public void RenderItem(AssetItem item)
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Render(item);
            _initCells.Add(item, cell);
        }
    
    }
}