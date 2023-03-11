using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _itemKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteract>() != null)
        {
            collision.gameObject.GetComponent<PlayerInteract>().InteractWithItem(_itemKey);
            Destroy(this.gameObject);
        }
    }
}
