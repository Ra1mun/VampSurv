using System;
using UnityEngine;

public class ItemTriggerInteractable : ItemInteractable
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.Route<Interaction>(Interact);
    }
}
