using UnityEngine;

namespace Core.Unit
{
    public abstract class Unit : MonoBehaviour
    {
        protected UnitType _type;
        public UnitType Type => _type;
    }

    public enum UnitType
    {
        Player,
        Enemy,
        Item
    }
}