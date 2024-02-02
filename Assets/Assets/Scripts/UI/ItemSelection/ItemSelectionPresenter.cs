using System;
using UnityEngine;

public class ItemSelectionPresenter
{
    private readonly ItemSelectionVisitor _model;
    private readonly AssetItemGenerator _generator;
    private readonly ItemSelectionView _view;
    

    public ItemSelectionPresenter(
        ItemSelectionView view,
        ItemSelectionVisitor model,
        AssetItemGenerator generator)
    {
        _model = model;
        _generator = generator;
        _view = view;
        
    }

    public void Enable()
    {
        _model.OnItemSelectionEvent += OnItemSelection;
    }

    private void OnItemSelection()
    {
        _view.Init(_generator.GenerateAssetItem(3));
    }

    public void Disable()
    {
        _model.OnItemSelectionEvent -= OnItemSelection;
    }
}
