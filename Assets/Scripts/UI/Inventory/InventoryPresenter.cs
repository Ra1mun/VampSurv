using Assets.Scripts.Inventory;
using Assets.Scripts.Item;
using Assets.Scripts.Item.AssetItem;
using Assets.Scripts.Item.ItemSelection;
using Item;

namespace Assets.Scripts.UI.Inventory
{
    public class InventoryPresenter
    {
        private readonly global::Item.Inventory.Inventory _model;
        private readonly InventoryView _view;
        private readonly ItemDataBase _data;
        private readonly ItemSelectionObserver _observer;

        public InventoryPresenter(
            global::Item.Inventory.Inventory model, 
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
            _model.ActivateAndAddItem(_data.GetConfig(item.ID));
            _model.AddStats(item.ID);
        }

        public void Disable()
        {
            _observer.OnItemAdded += OnItemAdded;
        }
    }
}
