using System;
using System.Collections.Generic;
using Core.Item.AssetItem;
using UnityEngine;

namespace Core.UI.ItemSelection
{
    public class ItemSelectionView : UIPanel
    {
        [SerializeField] private ItemSelectButton _prefabSelectButton;
        [SerializeField] private RectTransform _container;

        private readonly List<ItemSelectButton> _initButtons = new();
        public event Action<AssetItem> OnItemSelectedEvent;

        public void Init(List<AssetItem> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                var button = Instantiate(_prefabSelectButton, _container);
                button.Init(items[i]);
                _initButtons.Add(button);
            }
        }

        public override void Open()
        {
            foreach (var buttons in _initButtons) buttons.OnItemSelectButtonClickEvent += OnItemSelected;
        }

        private void OnItemSelected(AssetItem item)
        {
            OnItemSelectedEvent?.Invoke(item);
        }

        public override void Close()
        {
            for (var i = 0; i < _initButtons.Count; i++)
            {
                _initButtons[i].OnItemSelectButtonClickEvent += OnItemSelected;
                Destroy(_initButtons[i].gameObject);
            }

            _initButtons.Clear();
        }
    }
}