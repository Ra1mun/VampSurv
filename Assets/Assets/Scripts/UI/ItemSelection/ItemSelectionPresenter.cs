using System;
using UnityEngine;

public class ItemSelectionPresenter
{
    private readonly ItemSelectionVisitor _visitor;
    private readonly AssetItemGenerator _generator;
    private readonly ItemSelectionView _view;
    

    public ItemSelectionPresenter(
        ItemSelectionView view,
        ItemSelectionVisitor visitor,
        AssetItemGenerator generator)
    {
        _visitor = visitor;
        _generator = generator;
        _view = view;
        
    }

    public void Enable()
    {
        _visitor.OnItemSelectionEvent += OnItemSelection;
    }

    private void OnItemSelection()
    {
        _view.Init(_generator.GenerateAssetItem(3));
    }

    public void Disable()
    {
        _visitor.OnItemSelectionEvent -= OnItemSelection;
    }
}
