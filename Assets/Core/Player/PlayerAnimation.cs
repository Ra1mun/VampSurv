using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void InputDirection(Vector2 direction)
        {
        }
    }
}