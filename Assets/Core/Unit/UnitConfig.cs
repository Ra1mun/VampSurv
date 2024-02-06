using UnityEngine;

namespace Core.Unit
{
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private CommonStats _commonStats;
        public CommonStats CommonStats => _commonStats;
    }
}