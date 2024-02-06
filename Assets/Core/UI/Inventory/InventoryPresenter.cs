using Assets.Scripts.Item;
using Core.Item.AssetItem;
using Core.Item.ItemSelection;

namespace Core.UI.Inventory
{
    public class InventoryPresenter
    {
        private readonly ItemDataBase _data;
        private readonly Core.Inventory.Inventory _model;
        private readonly ItemSelectionObserver _observer;
        private readonly InventoryView _view;

        public InventoryPresenter(
            Core.Inventory.Inventory model,
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