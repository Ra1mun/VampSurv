using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionView : MonoBehaviour
{
    [SerializeField] List<ItemSelectButton> itemsButtons;
    [SerializeField] ItemSelectionSetup setup;
    [SerializeField] int _buttonsCount;

    List<AssetItem> itemsToSelect;

    public Action<AssetItem> OnItemSelected;
    private void OnEnable()
    {
        
    }
    public void ItemSelected(AssetItem item)
    {
        OnItemSelected?.Invoke(item);
    }
    public void Open()
    {
        itemsToSelect = setup.GenerateButtons(_buttonsCount);
        for (int i = 0; i < itemsToSelect.Count; i++)
        {
            itemsButtons[i].Init(itemsToSelect[i]);
            itemsButtons[i].SelectedItem += ItemSelected;
        }
        /*foreach (var button in itemsButtons)
        {
            button.gameObject.SetActive(true);
        }*/
    }
    public void Close()
    {
        foreach (var button in itemsButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
