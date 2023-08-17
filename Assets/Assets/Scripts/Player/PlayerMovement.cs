using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : EntityMoveable
{
    [SerializeField] private Player _player;

    private Rigidbody2D _rigidbody;

    private float _speed => _player.Stats.GetStats().MoveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.deltaTime);
    }
    
}