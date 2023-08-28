using System;
using UnityEngine;

public abstract class ItemInteractable : MonoBehaviour
{
    [SerializeField] protected AssetItem _item;

    public abstract event Action OnInteracted;
    
    protected abstract void Interact(Interaction player);
}