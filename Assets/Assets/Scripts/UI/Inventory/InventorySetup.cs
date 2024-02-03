using UnityEngine;
using UnityEngine.Serialization;

public class InventorySetup : MonoBehaviour
{
    [SerializeField] private InventoryView _view;
    [SerializeField] private InventoryModel _model;
    [FormerlySerializedAs("statsData")] [FormerlySerializedAs("_data")] [SerializeField] private ItemDataBase data;
    [SerializeField] private Inventory _inventory;
    private InventoryPresenter _presenter;

    private void OnEnable()
    {
        _presenter = new InventoryPresenter(_inventory, _model, _view, data);
        
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
