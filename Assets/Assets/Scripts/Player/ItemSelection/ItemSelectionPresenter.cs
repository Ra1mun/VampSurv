using System;

public class ItemSelectionPresenter
{
    Interaction model;
    ItemSelectionView view;

    public Action<AssetItem> OnItemSelected;

    public ItemSelectionPresenter(Interaction model, ItemSelectionView view)
    {
        this.model = model;
        this.view = view;
    }
    public void Enable()
    {
        model.OnItemSelection += SelectItem;
        view.OnItemSelected += ItemSelected;
    }
    void SelectItem()
    {
        view.Open();
    }
    public void ItemSelected(AssetItem item)
    {
        model.Visit(item);
        OnItemSelected?.Invoke(item);
        view.Close();
    }
}
