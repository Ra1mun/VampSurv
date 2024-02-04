using Assets.Scripts.Inventory;

public class InventoryPresenter
{
    private readonly Inventory _model;
    private readonly InventoryView _view;
    private readonly ItemDataBase _data;
    private readonly ItemSelectionObserver _observer;

    public InventoryPresenter(
        Inventory model, 
        InventoryView view, 
        ItemDataBase data, 
        ItemSelectionObserver observer)
    {
        _model = model;
        _view = view;
        _data = data;
        _observer = observer;
    }

    public void Enable()
    {
        _observer.OnItemAdded += OnItemAdded;
    }

    private void OnItemAdded(AssetItem item)
    {
        _view.RenderItem(item);
        _model.AddItem(_data.GetItem(item.ID));
    }

    public void Disable()
    {
        _observer.OnItemAdded += OnItemAdded;
    }
}
