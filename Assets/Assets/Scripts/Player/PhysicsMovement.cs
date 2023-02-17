using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMovement : MonoBehaviour
{ 
    private Rigidbody2D _rigidbody;
    
    private float _speed;

    public void Init(float speed)
    {
        _speed = speed;
    }
    public void MoveDirection(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + (direction * _speed * Time.deltaTime));
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
