using System.Collections.Generic;
using Core.UI.Attribute;
using Core.UI.ItemSelection;
using UnityEngine;

namespace Core.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private Player.Experience.Experience _experience;
        [SerializeField] private ItemSelectionView _itemView;
        [SerializeField] private AttributeView _attributeView;
        [SerializeField] private UIRoot _uiRoot;

        private readonly List<UIPanel> _initPanels = new();

        private void Awake()
        {
            _initPanels.Add(_itemView);
            _initPanels.Add(_attributeView);
        }

        public void Show(UIPanel panel)
        {
            if (_initPanels.Contains(panel))
            {
                panel.transform.SetParent(_uiRoot.Container);
                panel.transform.localPosition = Vector3.zero;
                panel.transform.localRotation = Quaternion.identity;
                panel.transform.localScale = Vector3.one;

                panel.Open();
            }
        }

        public void Close(UIPanel panel)
        {
            if (_initPanels.Contains(panel))
            {
                panel.Close();

                panel.transform.SetParent(_uiRoot.PoolContainer);
            }
        }
    }
}