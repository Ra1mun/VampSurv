using UnityEngine;

namespace Core.Unit
{
    public abstract class UnitMoveable : MonoBehaviour
    {
        public abstract void Move(Vector2 direction);
    }
}