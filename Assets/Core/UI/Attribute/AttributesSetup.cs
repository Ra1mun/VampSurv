using Core.Player;
using Core.Player.Attribute;
using UnityEngine;

namespace Core.UI.Attribute
{
    public class AttributesSetup : MonoBehaviour
    {
        [SerializeField] private Attributes _attributes;
        [SerializeField] private AttributeView _attributeView;
        [SerializeField] private PlayerLevelObserver _observer;
        [SerializeField] private UIPanelController _uiPanelController;

        private AttributePresenter attributePresenter;

        private void OnEnable()
        {
            attributePresenter = new AttributePresenter(
                _attributes,
                _attributeView,
                _observer,
                _uiPanelController);

            attributePresenter.Enable();
        }

        private void OnDisable()
        {
            attributePresenter.Disable();
        }
    }
}