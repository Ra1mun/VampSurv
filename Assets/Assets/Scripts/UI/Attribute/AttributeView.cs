using System;
using Assets.Scripts.UI.Attribute;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AttributeView : UIPanel
{
    [SerializeField] private AttributeButton[] _attributeButtons;

    public event Action<AttributeType> OnAttributeButtonClickEvent;

    private void OnAttributeButtonClick(AttributeType attributeType)
    {
        OnAttributeButtonClickEvent?.Invoke(attributeType);
    }
    
    public override void Open()
    {
        for (int i = 0; i < _attributeButtons.Length; i++)
        {
            _attributeButtons[i].OnAttributeButtonClickEvent += OnAttributeButtonClick;
        }
    }

    public override void Close()
    {
        for (int i = 0; i < _attributeButtons.Length; i++)
        {
            _attributeButtons[i].OnAttributeButtonClickEvent -= OnAttributeButtonClick;
        }
    }

    
}
