using System;
using Assets.Scripts.UI;
using UnityEngine;

public class ItemSelectionPresenter
{
    private readonly ItemSelectionVisitor _visitor;
    private readonly AssetItemGenerator _generator;
    private readonly UIPanelController _uiPanelController;
    private readonly ItemSelectionView _view;
    

    public ItemSelectionPresenter(
        ItemSelectionView view,
        ItemSelectionVisitor visitor,
        AssetItemGenerator generator,
        UIPanelController uiPanelController)
    {
        _visitor = visitor;
        _generator = generator;
        _uiPanelController = uiPanelController;
        _view = view;
        
    }

    public void Enable()
    {
        _visitor.OnItemSelectionEvent += OpenItemSelection;
    }

    private void OpenItemSelection()
    {
        _view.Init(_generator.GenerateAssetItem(3));
        _uiPanelController.Show(_view);
        _view.OnItemSelectedEvent += OnItemSelected;
    }

    private void OnItemSelected(ItemID itemID)
    {
        _view.OnItemSelectedEvent -= OnItemSelected;
        _uiPanelController.Close(_view);
        //add to inventory
    }

    public void Disable()
    {
        _visitor.OnItemSelectionEvent -= OpenItemSelection;
    }
}
