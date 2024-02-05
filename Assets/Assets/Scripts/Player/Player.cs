using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : global::Assets.Scripts.Unit.Unit
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