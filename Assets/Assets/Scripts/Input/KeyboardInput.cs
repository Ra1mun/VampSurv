using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _physicsMovement;

    private void Update()
    {
        _physicsMovement.MoveDirection(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}
