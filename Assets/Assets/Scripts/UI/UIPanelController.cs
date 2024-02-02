using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private Experience _experience;
        [SerializeField] private ItemSelectionView _itemView;
        [SerializeField] private AttributeView _attributeView;
        [SerializeField] private UIRoot _uiRoot;

        private Dictionary<Type, UIPanel> _uiPanels = new Dictionary<Type, UIPanel>();

        private void Awake()
        {
            _uiPanels.Add(_itemView.GetType(), _itemView);
            _uiPanels.Add(_attributeView.GetType(), _attributeView);
        }

        public void Show<T>() where T : UIPanel
        {
            var type = typeof(T);
            if (_uiPanels.ContainsKey(type))
            {
                var view = _uiPanels[type];
                
                view.transform.SetParent(_uiRoot.Container);
                view.transform.localPosition = Vector3.zero;
                view.transform.localRotation = Quaternion.identity;
                view.transform.localScale = Vector3.one;

                var component = view.GetComponent<T>();
                component.Open();
            }
        }
        
        public void Close<T>() where T : UIPanel
        {
            var type = typeof(T);
            if (_uiPanels.ContainsKey(type))
            {
                var view = _uiPanels[type];
                
                view.transform.SetParent(_uiRoot.PoolContainer);
                
                var component = view.GetComponent<T>();
                component.Close();
            }
        }
    }
}