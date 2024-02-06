using Core.Extension;
using Core.Item.ItemSelection;
using UnityEngine;

namespace Core.Item.Interactable
{
    public class ItemTriggerInteractable : MonoBehaviour
    {
        [SerializeField] private AssetItem.AssetItem _item;

        private void OnTriggerEnter2D(Collider2D col)
        {
            col.gameObject.Route<ItemSelectionObserver>(Interact);
        }

        private void Interact(ItemSelectionObserver player)
        {
            player.AddItem(_item);
            Destroy(gameObject);
        }
    }
}