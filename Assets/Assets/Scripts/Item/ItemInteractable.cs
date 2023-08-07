using UnityEngine;
using UnityEngine.Serialization;

public abstract class InteractableItem : MonoBehaviour
{
    [SerializeField] private ItemID _itemID;
    protected abstract void Interact(PlayerInteract player);
}