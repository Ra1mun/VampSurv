using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public event Action<string> OnInteracted;

    public void InteractWithItem(string itemKey)
    {
        OnInteracted.Invoke(itemKey);
    }
}