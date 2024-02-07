using Core.Unit;
using UnityEngine;

namespace Core.Player
{
    public class Player : Unit.Unit
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerStats _stats;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _type = UnitType.Player;
            _stats.Initialize(_playerConfig.CommonStats);
        }
    }
}