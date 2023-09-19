using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Projectile))]
public abstract class ProjectileMovement : MonoBehaviour
{
    [SerializeField] protected Projectile _projectile;
    [SerializeField] protected Rigidbody2D projectileRigidbody;
    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move() { }
}
