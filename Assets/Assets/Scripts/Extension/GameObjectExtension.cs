using System;
using UnityEngine;

public static class GameObjectExtension
{
    public static void Route<T>(this GameObject container, Action<T> handler)
    {
        if (container.GetComponent<T>() != null)
            handler?.Invoke(container.GetComponent<T>());
    }
}