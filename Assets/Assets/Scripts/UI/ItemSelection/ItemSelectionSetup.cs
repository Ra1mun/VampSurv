using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory;
using Assets.Scripts.UI;
using Assets.Scripts.UI.ItemSelection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

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
