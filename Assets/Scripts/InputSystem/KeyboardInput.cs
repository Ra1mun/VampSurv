using System;
using UnityEngine;

namespace InputSystem
{
    public class KeyboardInput : MonoBehaviour
    {
        public event Action<Vector2> OnInput;
    
        private void FixedUpdate()
        {
            OnInput?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
    }
}