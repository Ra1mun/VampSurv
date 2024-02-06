using UnityEngine;

namespace Core.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _poolContainer;
        public RectTransform Container => _container;
        public RectTransform PoolContainer => _poolContainer;
    }
}