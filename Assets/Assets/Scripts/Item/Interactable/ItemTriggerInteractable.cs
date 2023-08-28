using System;
using UnityEngine;

public class ItemTriggerInteractable : ItemInteractable
{
    public override event Action OnInteracted;
    protected override void Interact(Interaction player)
    {
        player.InteractWithItem(_item);
        OnInteracted?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.Route<Interaction>(Interact);
    }
}
