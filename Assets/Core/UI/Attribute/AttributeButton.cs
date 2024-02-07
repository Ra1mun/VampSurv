using System;
using Core.Player.Attribute;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Attribute
{
    public class AttributeButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AttributeType _attributeType;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnAttributeButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnAttributeButtonClick);
        }

        public event Action<AttributeType> OnAttributeButtonClickEvent;

        private void OnAttributeButtonClick()
        {
            OnAttributeButtonClickEvent?.Invoke(_attributeType);
        }
    }
}