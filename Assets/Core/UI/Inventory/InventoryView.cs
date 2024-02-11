using System.Collections.Generic;
using Core.Item.AssetItem;
using UnityEngine;

namespace Core.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryCell _inventoryCellTemplate;
        [SerializeField] private RectTransform _container;

        private readonly List<InventoryCell> _initCells = new List<InventoryCell>();

        public void RenderItem(AssetItem item)
        {
            var cell = Instantiate(_inventoryCellTemplate, _container);
            cell.Render(item);
            _initCells.Add(cell);
        }
    }
}