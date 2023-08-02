using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : EntityMoveable
{
    [SerializeField] private Player _player;
    
    [SerializeField] private KeyboardInput _input;

    private Rigidbody2D _rigidbody;

    private float _speed => _player.Config.MoveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.OnInput += Move;
    }

    public override void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _input.OnInput -= Move;
    }
}