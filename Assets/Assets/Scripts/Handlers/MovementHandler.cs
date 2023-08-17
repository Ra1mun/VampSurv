using System;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private KeyboardInput _input => KeyboardInput.Instance;
    [SerializeField] private PlayerMovement _player;
    
    private void OnEnable()
    {
        _input.OnInput += OnInput;
    }
    
    public void OnEnableInput()
    {
        _input.OnInput -= OnInput;
    }
    
    private void OnInput(Vector2 direction)
    {
        _player.Move(direction);
    }
    
    private void OnDisable()
    {
        _input.OnInput -= OnInput;
    }
    
    public void OnDisableInput()
    {
        _input.OnInput -= OnInput;
    }
}
