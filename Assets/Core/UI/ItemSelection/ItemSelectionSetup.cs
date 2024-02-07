using Core.Item.AssetItem;
using Core.Item.ItemSelection;
using Core.Pause.Scripts;
using Core.Player;
using UnityEngine;

namespace Core.UI.ItemSelection
{
    public class ItemSelectionSetup : MonoBehaviour
    {
        [SerializeField] private ItemSelectionView _view;
        [SerializeField] private PlayerLevelObserver _playerLevelObserver;
        [SerializeField] private AssetItemSelectionConfig _config;
        [SerializeField] private ItemSelectionObserver _observer;
        [SerializeField] private UIPanelController _uiPanelController;

        private ItemSelectionPresenter _presenter;

        private void OnEnable()
        {
            _presenter = new ItemSelectionPresenter(
                _view,
                _playerLevelObserver,
                new AssetItemGenerator(_config),
                _observer,
                _uiPanelController);

            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}