using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public event Action<Vector2> OnInput;
    
    private void FixedUpdate()
    {
        OnInput?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}