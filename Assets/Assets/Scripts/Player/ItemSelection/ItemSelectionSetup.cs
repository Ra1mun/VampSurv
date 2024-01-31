using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSelectionSetup : MonoBehaviour
{
    [SerializeField] private Interaction interaction;
    [SerializeField] private ItemSelectionView view;
    [SerializeField] public List<AssetItem> itemsPool;
    private ItemSelectionPresenter presenter;
    void OnEnable()
    {
        presenter = new ItemSelectionPresenter(interaction,view);
        presenter.OnItemSelected += RemoveSelectedItem;
        presenter.Enable();
    }
    public List<AssetItem> GenerateButtons(int buttonsCount)
    {
        var buttons = new List<AssetItem>();
        for(int n = 0; n<buttonsCount;n++)
        {
            //int ind = Random.Range(0,itemsPool.Count);
            buttons.Add(itemsPool[n]);
        }
        return buttons;
    }
    public void RemoveSelectedItem(AssetItem item)
    {
        itemsPool.Remove(item);
    }
    
}
