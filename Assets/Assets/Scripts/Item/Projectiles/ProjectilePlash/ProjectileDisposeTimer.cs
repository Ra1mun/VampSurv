using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDisposeTimer : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _countdown;
    [SerializeField] private Area _area;
    private float _elapsedTime;

    private void Update()
    {
        if (_area.IsAreaDisposed == true)
            return;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _countdown)
        {
            Dispose();
        }

    }
    private void Dispose()
    {
        _area.DisposeArea();
    }
}
