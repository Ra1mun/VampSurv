using Assets.Scripts.Inventory;
using Assets.Scripts.Item.ItemSelection;
using Extension;
using UnityEngine;

namespace Assets.Scripts.Item.Interactable
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
