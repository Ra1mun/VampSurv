using UnityEngine;

namespace Assets.Scripts.Item.Moveable
{
    public abstract class ItemMovable : MonoBehaviour
    {
        protected Transform _center => transform.parent;
        public abstract void Move();
    }
}
