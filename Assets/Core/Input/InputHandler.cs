using Core.Player;
using Core.Player.Movement;
using UnityEngine;

namespace Core.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private KeyboardInput _input;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerAnimation _animation;

        private void OnEnable()
        {
            _input.OnInput += OnInput;
        }

        private void OnDisable()
        {
            _input.OnInput -= OnInput;
        }

        public void OnEnableInput()
        {
            _input.OnInput -= OnInput;
        }

        private void OnInput(Vector2 direction)
        {
            _movement.Move(direction);
            //_animation.InputDirection(direction);
        }

        public void OnDisableInput()
        {
            _input.OnInput -= OnInput;
        }
    }
}