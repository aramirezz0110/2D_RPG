using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToAdd : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private InventoryItem inventoryItemRef;
    [SerializeField] private int amountToAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.Player))
        {
            Inventory.Instance?.AddItem(inventoryItemRef, amountToAdd);
            Destroy(gameObject);
        }
    }
}
