using System;
using Assets.Scripts.Player.Attribute;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Attribute
{
    public class AttributeButton : MonoBehaviour
    {
        public event Action<AttributeType> OnAttributeButtonClickEvent;
        
        [SerializeField] private Button _button;
        [SerializeField] private AttributeType _attributeType;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnAttributeButtonClick);
        }

        private void OnAttributeButtonClick()
        {
            OnAttributeButtonClickEvent?.Invoke(_attributeType);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnAttributeButtonClick);
        }
    }
}