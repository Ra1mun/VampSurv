using System;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private KeyboardInput _input;
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
