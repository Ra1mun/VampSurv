    using System;
using UnityEngine;

public class ItemCircleMove : ItemMovable
{
    [SerializeField] private Item _item;
    
    [SerializeField] private float _radius = 0.5f; 
    
    private float _angle = 0;
    private float _speed => _item.Stats.GetStats().MoveSpeed;
    private Transform _center => transform.parent;
    
    public override void Move()
    {
        _angle += Time.deltaTime;

        var x = Mathf.Cos(_angle) * _radius;
        var y = Mathf.Cos(_angle) * _radius;
        transform.position = _center.position + new Vector3(x, y, 0);
    }
}
