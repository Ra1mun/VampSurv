using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesSetup : MonoBehaviour
{
    [SerializeField] private Attributes _attributes;
    [SerializeField] private AttributeView _attributeView;
    [SerializeField] private PlayerLevelObserver _observer;
    
    private AttributePresenter attributePresenter;
    
    private void OnEnable()
    {
        attributePresenter = new AttributePresenter(
            _attributes, 
            _attributeView,
            _observer);
        
        attributePresenter.Enable();
    }
    
    private void OnDisable()
    {
        attributePresenter.Disable();
    }
}
