public class InventoryPresenter
{
    private readonly Inventory _model;
    private readonly InventoryView _view;
    private readonly ItemDataBase _data;

    public InventoryPresenter(Inventory model, InventoryView view, ItemDataBase data)
    {
        _model = model;
        _view = view;
        _data = data;
    }

    public void Enable()
    {
        
    }

    private void OnItemAdded(AssetItem item)
    {
        //_view.RenderItem(item);
        _model.AddItem(_data.GetItem(item.ID));
    }

    public void Disable()
    {
        
    }
}
