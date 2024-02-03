using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionView : MonoBehaviour
{
    private const int buttonsCount = 3;
    
    [SerializeField] private ItemSelectButton[] itemsButtons;
    [SerializeField] private ItemSelectionSetup setup;
    
    private List<AssetItem> itemsToSelect;

    public Action<AssetItem> OnItemSelectedEvent;
    
    private void OnEnable()
    {
        itemsToSelect = setup.GenerateButtons(buttonsCount);
        for (int i = 0; i < buttonsCount; i++)
        {
            itemsButtons[i].Init(itemsToSelect[i]);
            itemsButtons[i].OnItemSelectButtonClickEvent += OnItemSelectButtonClick;
        }
    }
    private void OnItemSelectButtonClick(AssetItem item)
    {
        OnItemSelectedEvent?.Invoke(item);
    }
    
    public void Open()
    {
        foreach (var button in itemsButtons)
        {
            button.gameObject.SetActive(true);
        }
    }
    
    public void Close()
    {
        foreach (var button in itemsButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
