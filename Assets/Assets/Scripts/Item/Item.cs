using UnityEngine;

[RequireComponent(typeof(InteractableItem))]
public class Item : MonoBehaviour
{
    [SerializeField] private string _itemKey;

    public void TakeItem(PlayerInteract instance)
    {
        instance.InteractWithItem(_itemKey);
        Destroy(gameObject);
    }
}