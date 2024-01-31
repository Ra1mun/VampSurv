using System;
using UnityEngine;
using UnityEngine.UI;

public class AttributeView : MonoBehaviour
{
    [SerializeField] private Button _christianButton;
    [SerializeField] private Button _atheismButton;
    [SerializeField] private Button _paganismButton;

    public event Action<AttributeType> OnAttributeLevelChanged;

    private void OnEnable()
    {
        _christianButton.onClick.AddListener(OnChristianButtonClick);
        _atheismButton.onClick.AddListener(OnAtheismButtonClick);
        _paganismButton.onClick.AddListener(OnPaganismButtonClick);
    }

    private void OnChristianButtonClick()
    {
        OnAttributeLevelChanged?.Invoke(AttributeType.Christianity);
    }
    
    private void OnAtheismButtonClick()
    {
        OnAttributeLevelChanged?.Invoke(AttributeType.Atheism);
    }
    
    private void OnPaganismButtonClick()
    {
        OnAttributeLevelChanged?.Invoke(AttributeType.Paganism);
    }
    
    public void Close()
    {
        _christianButton.gameObject.SetActive(false);
        _atheismButton.gameObject.SetActive(false);
        _paganismButton.gameObject.SetActive(false);
    }

    public void Open()
    {
        _christianButton.gameObject.SetActive(true);
        _atheismButton.gameObject.SetActive(true);
        _paganismButton.gameObject.SetActive(true);
    }
}
