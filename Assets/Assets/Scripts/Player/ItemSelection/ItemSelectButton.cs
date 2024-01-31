using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectButton : MonoBehaviour
{
    [SerializeField] AssetItem _item;
    public Action<AssetItem> SelectedItem;
    public void Init(AssetItem item)
    {
        _item = item;
    }
    private void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click()
    {
        SelectedItem?.Invoke(_item);
    }
}
