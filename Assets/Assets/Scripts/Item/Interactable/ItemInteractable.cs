using System;
using UnityEngine;

public abstract class ItemInteractable : MonoBehaviour
{
    [SerializeField] protected AssetItem _item;

    protected abstract void Interact(Interaction player);
}