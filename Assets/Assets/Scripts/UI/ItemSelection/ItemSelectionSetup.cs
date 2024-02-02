using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI.ItemSelection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemSelectionSetup : MonoBehaviour
{
    [SerializeField] private ItemSelectionView _view;
    [SerializeField] private ItemSelectionVisitor _model;
    [SerializeField] private AssetItemSelectionConfig _config;

    private ItemSelectionPresenter _presenter;

    private void OnEnable()
    {
        _presenter = new ItemSelectionPresenter(_view, _model, new AssetItemGenerator(_config));
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
