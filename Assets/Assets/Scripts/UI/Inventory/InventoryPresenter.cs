public class InventoryPresenter
{
    private readonly Inventory _inventory;
    private readonly InventoryModel _model;
    private readonly InventoryView _view;
    private readonly ItemDataBase _data;

    public InventoryPresenter(Inventory inventory,InventoryModel model, InventoryView view, ItemDataBase data)
    {
        _inventory = inventory;
        _model = model;
        _view = view;
        _data = data;
    }

    public void Enable()
    {
        _model.OnItemAdded += OnItemAdded;
        _model.OnItemRemoved += OnItemRemoved;
    }

    private void OnItemAdded(AssetItem item)
    {
        //_view.RenderItem(item);
        _inventory.ActivateItem(_data.GetItem(item.ID));
    }

    private void OnItemRemoved(AssetItem item)
    {
        
    }

    public void Disable()
    {
        _model.OnItemAdded -= OnItemAdded;
    }
}
