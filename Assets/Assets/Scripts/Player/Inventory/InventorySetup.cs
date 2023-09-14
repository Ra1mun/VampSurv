using UnityEngine;

public class InventorySetup : MonoBehaviour
{
    [SerializeField] private InventoryView _view;
    [SerializeField] private InventoryModel _model;
    [SerializeField] private ItemDataBase _data;
    private InventoryPresenter _presenter;

    private void OnEnable()
    {
        _presenter = new InventoryPresenter(_model, _view, _data);
        
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
