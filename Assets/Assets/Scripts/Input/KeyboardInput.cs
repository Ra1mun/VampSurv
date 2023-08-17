using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public event Action<Vector2> OnInput;

    public static KeyboardInput Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        OnInput?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}