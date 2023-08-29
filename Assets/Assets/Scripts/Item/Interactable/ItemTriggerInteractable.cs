using System;
using UnityEngine;

public class ItemTriggerInteractable : ItemInteractable
{
    protected override void Interact(Interaction player)
    {
        player.InteractWithItem(_item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.Route<Interaction>(Interact);
    }
}
