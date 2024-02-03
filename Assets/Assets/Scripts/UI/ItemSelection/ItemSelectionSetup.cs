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
    [FormerlySerializedAs("_model")] [SerializeField] private ItemSelectionVisitor _visitor;
    [SerializeField] private AssetItemSelectionConfig _config;

    private ItemSelectionPresenter _presenter;

    private void OnEnable()
    {
        _presenter = new ItemSelectionPresenter(_view, _visitor, new AssetItemGenerator(_config));
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}
