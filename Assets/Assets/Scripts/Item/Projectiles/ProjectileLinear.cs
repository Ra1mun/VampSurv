using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLinear : Projectile
{
    private float _radius;
    private float _damage;
    private float _speed;
    private Vector2 _direction;

    public void Initialize(float speed, float radius, float damage, Vector2 dir)
    {
        _radius = radius;
        _damage = damage;
        _speed = speed;
        _direction = dir;
    }
    private void Move()
    {
        Vector2 target = _direction;
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Move();
    }
}
