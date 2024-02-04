using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySetup : MonoBehaviour
{
    [SerializeField] private ItemSelectionObserver _observer;
    [SerializeField] private InventoryView _view;
    [SerializeField] private ItemDataBase _data;
    [SerializeField] private Inventory _model;
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
