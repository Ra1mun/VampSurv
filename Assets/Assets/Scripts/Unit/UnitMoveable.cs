using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class UnitMoveable : MonoBehaviour
    {
        public abstract void Move(Vector2 direction);
    }
}
