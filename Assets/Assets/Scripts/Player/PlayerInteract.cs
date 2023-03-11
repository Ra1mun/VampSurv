using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public event Action<string> OnInteracted;

    public void InteractWithItem(string itemKey)
    {
        OnInteracted.Invoke(itemKey);
    }
}
