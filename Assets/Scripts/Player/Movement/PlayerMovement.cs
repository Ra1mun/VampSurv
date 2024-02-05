using Assets.Scripts.Unit;
using Player;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : UnitMoveable
    {
        [SerializeField] private PlayerStats _playerStats;

        private Rigidbody2D _rigidbody;

        private float _speed => _playerStats.GetStats().MoveSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void Move(Vector2 direction)
        {

            _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.deltaTime);
        }
    
    }
}