using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private string _itemKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerInteract>(out PlayerInteract instance))
        {
            instance.InteractWithItem(_itemKey);
            Destroy(gameObject);
        }
    }
}