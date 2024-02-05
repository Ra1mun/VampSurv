using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Item.AssetItem;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    public event Action<AssetItem> OnItemSelectButtonClickEvent;
    
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    
    private  AssetItem _item;
    
    public void Init(AssetItem item)
    {
        _item = item;
        _image.sprite = item.Icon;
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnItemSelectButtonClick);
    }
    
    private void OnItemSelectButtonClick()
    {
        OnItemSelectButtonClickEvent?.Invoke(_item);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnItemSelectButtonClick);
    }
}
