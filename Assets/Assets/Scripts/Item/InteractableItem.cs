using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    private Item _item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.Route<PlayerInteract>(_item.TakeItem);
    }

    private void Initialize(Item item)
    {
        _item = item;
    }
}