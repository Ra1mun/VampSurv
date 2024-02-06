using System;
using Core.Item.AssetItem;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.ItemSelection
{
    public class ItemSelectButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        private AssetItem _item;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnItemSelectButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnItemSelectButtonClick);
        }

        public event Action<AssetItem> OnItemSelectButtonClickEvent;

        public void Init(AssetItem item)
        {
            _item = item;
            _image.sprite = item.Icon;
        }

        private void OnItemSelectButtonClick()
        {
            OnItemSelectButtonClickEvent?.Invoke(_item);
        }
    }
}