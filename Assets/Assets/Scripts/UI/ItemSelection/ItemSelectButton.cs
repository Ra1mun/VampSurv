using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    public Action<AssetItem> OnItemSelectButtonClickEvent;
    
    [SerializeField] private Button _button;
    
    private AssetItem _item;
    
    public void Init(AssetItem item)
    {
        _item = item;
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
        _button.onClick.AddListener(OnItemSelectButtonClick);
    }
}
