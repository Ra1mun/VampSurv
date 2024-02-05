using Assets.Scripts.Inventory;
using Assets.Scripts.Item;
using Assets.Scripts.Item.ItemSelection;
using Item;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class InventorySetup : MonoBehaviour
    {
        [SerializeField] private ItemSelectionObserver _observer;
        [SerializeField] private InventoryView _view;
        [SerializeField] private ItemDataBase _data;
        [SerializeField] private global::Item.Inventory.Inventory _model;
        private InventoryPresenter _presenter;

        private void OnEnable()
        {
            _presenter = new InventoryPresenter(
                _model, 
                _view, 
                _data,
                _observer);
        
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}
