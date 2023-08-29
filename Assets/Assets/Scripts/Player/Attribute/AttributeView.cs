using System;
using UnityEngine;
using UnityEngine.UI;

public class AttributeView : MonoBehaviour
{
    [SerializeField] private Button _christianButton;
    [SerializeField] private Button _atheismButton;
    [SerializeField] private Button _paganismButton;

    public event Action<AttributeType> OnUpLevelAttribute;

    private void OnEnable()
    {
        _christianButton.onClick.AddListener(ChristianButtonClick);
        _atheismButton.onClick.AddListener(AtheismButtonClick);
        _paganismButton.onClick.AddListener(PaganismButtonClick);
    }

    private void ChristianButtonClick()
    {
        OnUpLevelAttribute?.Invoke(AttributeType.Christianity);
    }
    
    private void AtheismButtonClick()
    {
        OnUpLevelAttribute?.Invoke(AttributeType.Atheism);
    }
    
    private void PaganismButtonClick()
    {
        OnUpLevelAttribute?.Invoke(AttributeType.Paganism);
    }
    
    public void Close()
    {
        
    }

    public void Open()
    {
        
    }
}
