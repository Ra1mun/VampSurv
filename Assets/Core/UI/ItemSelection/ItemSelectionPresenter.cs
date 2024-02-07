using Core.Item.AssetItem;
using Core.Item.ItemSelection;
using Core.Player;

namespace Core.UI.ItemSelection
{
    public class ItemSelectionPresenter
    {
        private readonly AssetItemGenerator _generator;
        private readonly ItemSelectionObserver _observer;
        private readonly UIPanelController _uiPanelController;
        private readonly ItemSelectionView _view;
        private readonly PlayerLevelObserver _visitor;


        public ItemSelectionPresenter(
            ItemSelectionView view,
            PlayerLevelObserver visitor,
            AssetItemGenerator generator,
            ItemSelectionObserver observer,
            UIPanelController uiPanelController)
        {
            _visitor = visitor;
            _generator = generator;
            _observer = observer;
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

        private void OnItemSelected(AssetItem item)
        {
            _view.OnItemSelectedEvent -= OnItemSelected;
            _uiPanelController.Close(_view);
            _observer.AddItem(item);
        }

        public void Disable()
        {
            _visitor.OnItemSelectionEvent -= OpenItemSelection;
        }
    }
}