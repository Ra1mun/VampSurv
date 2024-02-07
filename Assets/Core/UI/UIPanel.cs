using UnityEngine;

namespace Core.UI
{
    public abstract class UIPanel : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
    }
}