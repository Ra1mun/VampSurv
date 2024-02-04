using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AttributeView : UIPanel
{
    [SerializeField] private AttributeButton[] _attributeButtons;

    public event Action<AttributeType> OnAttributeButtonClickEvent;

    private void OnEnable()
    {
        for (int i = 0; i < _attributeButtons.Length; i++)
        {
            _attributeButtons[i].Button.onClick.AddListener((() =>
            {
                OnAttributeButtonClick(_attributeButtons[i].AttributeType);
            }));
        }
    }

    private void OnAttributeButtonClick(AttributeType attributeType)
    {
        OnAttributeButtonClickEvent.Invoke(attributeType);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _attributeButtons.Length; i++)
        {
            _attributeButtons[i].Button.onClick.RemoveAllListeners();
        }
    }

    public override void Close()
    {
        for (int i = 0; i < _attributeButtons.Length; i++)
        {
            _attributeButtons[i].Button.gameObject.SetActive(false);
        }
    }

    public override void Open()
    {
        for (int i = 0; i < _attributeButtons.Length; i++)
        {
            _attributeButtons[i].Button.gameObject.SetActive(true);
        }
    }
}

[Serializable]
public class AttributeButton
{
    public Button Button => _button;
    public AttributeType AttributeType => _attributeType;
    
    [SerializeField] private Button _button;
    [SerializeField] private AttributeType _attributeType;
}