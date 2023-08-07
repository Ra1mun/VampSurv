using System;
using UnityEngine;

public abstract class ItemInteractable : MonoBehaviour
{
    [SerializeField] protected ItemID _itemID;
    
    public abstract event Action<ItemID> OnItemInteracted;

    protected abstract void Interact(PlayerInteract player);
}