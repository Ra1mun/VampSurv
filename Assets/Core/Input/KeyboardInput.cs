using System;
using UnityEngine;

namespace Core.Input
{
    public class KeyboardInput : MonoBehaviour
    {
        private void FixedUpdate()
        {
            OnInput?.Invoke(new Vector2(UnityEngine.Input.GetAxis("Horizontal"),
                UnityEngine.Input.GetAxis("Vertical")));
        }

        public event Action<Vector2> OnInput;
    }
}