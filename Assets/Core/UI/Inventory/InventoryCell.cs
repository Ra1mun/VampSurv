using Core.Item.AssetItem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Inventory
{
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameField;
        [SerializeField] private Image _icon;

        public void Render(AssetItem item)
        {
            _nameField.text = item.Name;
            _icon.sprite = item.Icon;
        }
    }
}