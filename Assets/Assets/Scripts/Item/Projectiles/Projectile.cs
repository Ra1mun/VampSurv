using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected Sprite _sprite;
    
    private float _radius;
    private float _damage;
    private float _speed;
    private Vector2 _direction;

    public void Initialize(float speed, float radius, float damage, Vector2 direction)
    {
        _radius = radius;
        _damage = damage;
        _speed = speed;
        _direction = direction;
    }
}
