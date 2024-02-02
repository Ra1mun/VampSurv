using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionView : UIPanel
{
    [SerializeField] private ItemSelectButton _prefabSelectButton;
    [SerializeField] private RectTransform _container;
    public event Action<AssetItem> OnItemSelectedEvent;

    private List<ItemSelectButton> _initButtons = new List<ItemSelectButton>();
    
    public void Init(List<AssetItem> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            var button = Instantiate(_prefabSelectButton, _container);
            button.Init(items[i]);
            _initButtons.Add(button);
        }
    }
    
    public override void Open()
    {
        foreach (var buttons in _initButtons)
        {
            buttons.OnItemSelectButtonClickEvent += OnItemSelected;
        }
    }

    private void OnItemSelected(AssetItem item)
    {
        OnItemSelectedEvent?.Invoke(item);
    }

    public override void Close()
    {
        foreach (var button in _initButtons)
        {
            button.OnItemSelectButtonClickEvent -= OnItemSelected;
        }
        
        _initButtons.Clear();
    }
}
