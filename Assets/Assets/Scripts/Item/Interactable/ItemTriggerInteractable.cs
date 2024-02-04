using System;
using Assets.Scripts.Inventory;
using UnityEngine;

public class ItemTriggerInteractable : MonoBehaviour
{
    [SerializeField] private AssetItem _item;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.Route<ItemSelectionObserver>(Interact);
    }

    private void Interact(ItemSelectionObserver player)
    {
        player.AddItem(_item);
    }
}
