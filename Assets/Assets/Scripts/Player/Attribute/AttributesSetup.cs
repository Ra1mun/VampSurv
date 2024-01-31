using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesSetup : MonoBehaviour
{
    [SerializeField] Attributes attributes;
    [SerializeField] AttributeView attributeView;
    private AttributePresenter attributePresenter;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        attributePresenter = new AttributePresenter(attributes, attributeView);
        attributePresenter.Enable();
        
    }
    private void OnDisable()
    {
        attributePresenter.Disable();
    }
}
