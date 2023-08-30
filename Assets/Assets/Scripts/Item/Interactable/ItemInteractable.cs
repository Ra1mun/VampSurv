using System;
using System.Security.Cryptography;
using UnityEngine;

public abstract class ItemInteractable : MonoBehaviour
{
    [SerializeField] protected AssetItem _item;

    protected void Interact(Interaction player)
    {
        player.Visit(_item);
        Destroy(gameObject);
    }
}