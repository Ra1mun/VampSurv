using System;
using UnityEngine;

public class ItemTriggerInteractable : ItemInteractable
{
    public override event Action<ItemID> OnItemInteracted;

    protected override void Interact(PlayerInteract player)
    {
        OnItemInteracted?.Invoke(_itemID);
        player.InteractWithItem(_itemID);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.Route<PlayerInteract>(Interact);
    }
}
