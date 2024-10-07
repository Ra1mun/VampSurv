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
            if(direction.x == 0 && direction.y == 0)
                _animator.SetBool("isWalk", false);
            else
                _animator.SetBool("isWalk", true);
        }
    }
}